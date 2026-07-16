using UnityEngine;

public class RobotController : AController, IMissionReceiver
{
    RobotView View;
    RobotModel Model;
    Camera mainCam;

    IMessageHandler messageHandler;
    IStationLocator stationLocator;

    public RobotController(AContext ctx, AModel model, AView view) : base(ctx, model, view)
    {
        View = view as RobotView;
        Model = model as RobotModel;
    }

    protected override void OnViewEnabled()
    {
        View.EventOnMouseClicked -= OnMouseClicked;
        View.EventOnMouseClicked += OnMouseClicked;

        View.EventOnDestinationReached -= OnDestinationReached;
        View.EventOnDestinationReached += OnDestinationReached;

        if(messageHandler == null)
        {
            messageHandler = context.GetData("MessageHandler") as IMessageHandler;
            messageHandler?.Register(this);
        }
    }

    protected override void OnViewDisabled()
    {
        View.EventOnMouseClicked -= OnMouseClicked;
        View.EventOnDestinationReached -= OnDestinationReached;

        messageHandler?.Unregister(this);
        messageHandler = null;
    }

    IStationLocator Locator
    {
        get
        {
            if(stationLocator == null)
                stationLocator = context.GetData("StationLocator") as IStationLocator;
            return stationLocator;
        }
    }

    void OnMouseClicked(Vector3 vPos)
    {
        if(mainCam == null)
        {
            mainCam = context.GetData("MainCam") as Camera;
            if(mainCam == null)
                return;
        }

        Ray ray = mainCam.ScreenPointToRay(vPos);
        if(Physics.Raycast(ray, out RaycastHit hit))
            View.MoveTo(hit.point);
    }

    // ---- IMissionReceiver ----

    public void OnMissionAssigned(RobotMission mission)
    {
        Debug.Log("[RobotCtrler] Mission assigned.");

        Model.AssignMission(mission);
        ExecuteCurrentCommand();
    }

    // ---- Mission executor ----

    void ExecuteCurrentCommand()
    {
        if(!Model.HasActiveMission)
            return;

        var cmd = Model.CurrentCommand;
        if(cmd == null)
            return;

        switch(cmd.Action)
        {
            case RobotActionType.MoveTo:
                MoveToTarget(cmd);
                break;                  // completion handled by arrival event

            case RobotActionType.PickUp:
                DoPickUp(cmd);
                AdvanceAndExecute();
                break;

            case RobotActionType.DropOff:
                DoDropOff(cmd);
                AdvanceAndExecute();
                break;

            case RobotActionType.Wait:
            default:
                AdvanceAndExecute();
                break;
        }
    }

    void OnDestinationReached()
    {
        if(!Model.HasActiveMission)
            return;

        var cmd = Model.CurrentCommand;
        if(cmd == null || cmd.Action != RobotActionType.MoveTo)
            return;

        View.StopMovement();
        AdvanceAndExecute();
    }

    void AdvanceAndExecute()
    {
        if(Model.MoveToNextCommand())
            ExecuteCurrentCommand();
        else
            Debug.Log("[RobotCtrler] Mission completed.");
    }

    void MoveToTarget(RobotCommand cmd)
    {
        if(Locator == null)
        {
            Debug.LogWarning("[RobotCtrler] StationLocator not available.");
            return;
        }

        View.MoveTo(Locator.GetPosition(cmd.Target));
    }

    void DoPickUp(RobotCommand cmd)
    {
        var cargo = Locator?.GetService(cmd.Target)?.TakeCargo(cmd.CargoTag);
        if(cargo != null)
        {
            View.LoadCargo(cargo);
            Model.SetCarriedCargo(cargo);
        }
        else
        {
            Debug.Log("[RobotCtrler] No available cargo to pick up.");
        }
    }

    void DoDropOff(RobotCommand cmd)
    {
        var cargo = Model.CarriedCargo;
        if(cargo == null)
            return;

        Locator?.GetService(cmd.Target)?.ReceiveCargo(cargo);
        Model.SetCarriedCargo(null);
    }
}
