using UnityEngine;

public class StationModule : AModule, IStationService
{
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

    public CargoComp TakeCargo(int cargoTag)
    {
        var pickup = view as PickupStationView;
        return pickup != null ? pickup.GetAvailableCargo() : null;
    }

    public void ReceiveCargo(CargoComp cargo)
    {
        var drop = view as DropStationView;
        if(drop != null)
            drop.DropOffCargo(cargo);
    }
}
