using UnityEngine;
using UnityEngine.Assertions;

public class RobotController : AController, IRobotActor
{
    RobotView View;
    Camera mainCam;

    public RobotController(AContext ctx, AModel model, AView view) : base(ctx, model, view)
    {
        View = view as RobotView;   
    }

    protected override void OnViewEnabled()
    {
        View.EventOnMouseClicked += OnMouseClicked;
    }

    protected override void OnViewDisabled() 
    {
        View.EventOnMouseClicked -= OnMouseClicked;
    }


    void OnMouseClicked(Vector3 vPos)
    {
        Debug.Log("[Robot] Mouse Clicked...");

        if(mainCam == null)
        {
            mainCam = context.GetData("MainCam") as Camera;
            Assert.IsNotNull(mainCam);
        }

        Ray ray = mainCam.ScreenPointToRay(vPos);
        RaycastHit hit;
        if(Physics.Raycast(ray, out hit))
        {
            View.NavMeshAgent.SetDestination(hit.point);
        }
    }

    public void StartNavigation()
    {
        var vPickUpStationPos = (Vector3)context.GetData("PickUpStationPos");// as Vector3;
        View.NavMeshAgent.SetDestination(vPickUpStationPos);// new Vector3(-5.16f, 0.43f, 3.93f));
    }

    public void PickUp(CargoComp cargo) 
    { 
        Debug.Log("[RobotCtrler] Picking Up......");

        if(cargo != null)
        {
            cargo.transform.SetParent(View.transform,  true);
            cargo.transform.localPosition = new Vector3(.0f, 1.5f, .0f);// Vector3.zero;

            View.NavMeshAgent.SetDestination( (Vector3)context.GetData("DropOffStationPos") );
        }
    } 
    public void DropDown(AModule dropOffStationModule) 
    {
        Debug.Log("[RobotCtrler] Drop Down.....");


        var station = dropOffStationModule as StationModule;
        if(station != null) 
            station.UnloadItem(View.transform.GetChild(0));

    }
}
