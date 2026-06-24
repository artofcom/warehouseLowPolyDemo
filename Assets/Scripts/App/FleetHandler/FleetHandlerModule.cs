using UnityEngine;

public class FleetHandlerModule : AModule
{    
    public override void Init(AContext ctx)
    {
        var model = new FleetHandlerModel();
        controller = new FleetHandlerController(ctx, model, view);
    }

    public override void Dispose()
    {
        base.Dispose();
    }
}
