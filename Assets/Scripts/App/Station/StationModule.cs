using System.Collections.Generic;
using UnityEngine;

public class StationModule : AModule
{   
    //[SerializeField] List<CargoComp> cargoBoxes;

    //public CargoComp GetCargo(int idx) 
    //    => cargoBoxes!=null && idx>=0 && idx<cargoBoxes.Count ? cargoBoxes[idx] : null;

    public override void Init(AContext ctx)
    {
        var model = new StationModel();
        controller = new StationController(ctx, this, model, view);
    }

    public override void Dispose()
    {
        base.Dispose();
    }

    public Vector3 GetViewPosition()
    {
        return (controller as StationController).GetViewPosition();
    }

    public void UnloadItem(Transform trCargo)
    {
        (controller as StationController).UnloadItem(trCargo);
    }

    public CargoComp GetCargo()
    {
        return (controller as StationController).GetCargo();
    }
}
