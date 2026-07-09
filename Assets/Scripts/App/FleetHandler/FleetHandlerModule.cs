using UnityEngine;

public class FleetHandlerModule : AModule
{   
    [SerializeField] RobotModule robotModule;

    public override void Init(AContext ctx)
    {
        ctx.UpdateData("Robot", robotModule);
        var model = new FleetHandlerModel();
        controller = new FleetHandlerController(ctx, model, view);
    }

    public override void Dispose()
    {
        base.Dispose();
    }
}
