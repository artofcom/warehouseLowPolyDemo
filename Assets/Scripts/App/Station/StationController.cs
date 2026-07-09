using UnityEngine;
using UnityEngine.Assertions;

public class StationController : AController
{
    StationView View;
    public StationController(AContext ctx, AModel model, AView view) : base(ctx, model, view)
    {
        View = view as StationView;

        View.EventOnRobotArrived += OnRobotArrived;
    }

    void OnRobotArrived(IRobotActor actor)
    {
        if(View as DropStationView != null)
            actor.DropDown();
        else if(View as PickupStationView != null)
            actor.PickUp();
    }


}
