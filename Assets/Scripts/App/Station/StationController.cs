using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Assertions;

public class StationController : AController
{
    StationModule Module;
    StationView View;
    public StationController(AContext ctx, AModule module, AModel model, AView view) : base(ctx, model, view)
    {
        Module = module as StationModule;
        View = view as StationView;

        View.EventOnRobotArrived += OnRobotArrived; 
    }

    void OnRobotArrived(IRobotActor actor)
    {
        if(View as DropStationView != null)
            actor.DropDown(Module);
        else if(View as PickupStationView != null)
        {
            var trBox = GetAvailableCargo();
            if(trBox != null)
                actor.PickUp(trBox);
        }
    }

    CargoComp GetAvailableCargo()
    {
        Assert.IsNotNull(Module);
        return Module.GetCargo();
    }

    public Vector3 GetViewPosition()
    {
        return View.transform.position;
    }

    public void UnloadItem(Transform cargo)
    {
        cargo.transform.SetParent(View.transform, true);
        cargo.transform.localPosition = new Vector3(.0f, 1.0f, 0.3f);// Vector3.zero;
    }
    public CargoComp GetCargo()
    {
        return View.transform.childCount>0 ? View.transform.GetChild(0).GetComponent<CargoComp>() : null;
    }

}
