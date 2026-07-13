using UnityEngine;
using UnityEngine.Assertions;
using System.Collections.Generic;

public class StationController : AController
{
    StationModule Module;
    StationView View;

    List<ITransportable> cargos = new List<ITransportable>();

    public StationController(AContext ctx, AModule module, AModel model, AView view) : base(ctx, model, view)
    {
        Module = module as StationModule;
        View = view as StationView;

        View.EventOnRobotArrived += OnRobotArrived; 
    }

    void OnRobotArrived(IRobotActor actor)
    {
        if(View as DropStationView != null)
            UnloadCargo(actor); //actor.DropDown(Module);
        else if(View as PickupStationView != null)
        {
            var trBox = GetAvailableCargo();
            if(trBox != null)
                actor.PickUp(trBox as ITransportable);
            else 
                Debug.Log("There's no avaliable cargo...");
        }
    }

    void UnloadCargo(IRobotActor robot)
    {
        var cargo = robot.GetCargo();
        Assert.IsNotNull(cargo);
        robot.UnloadCargo();

        var cargoComp = cargo as CargoComp;
        Assert.IsNotNull(cargoComp);
        this.cargos.Add(cargoComp);
        
        var dropStationView = View as DropStationView;
        Assert.IsNotNull(dropStationView);
        dropStationView.UnloadCargo(cargoComp);
    }

    CargoComp GetAvailableCargo()
    {
        Assert.IsNotNull(Module);
        return GetCargo();
    }

    public Vector3 GetViewPosition()
    {
        return View.transform.position;
    }
    
    CargoComp GetCargo()
    {
        return View.transform.childCount>0 ? View.transform.GetChild(0).GetComponent<CargoComp>() : null;
    }

}
