public class RobotModule : AModule
{
    public override void Init(AContext ctx)
    {
        var model = new RobotModel();
        controller = new RobotController(ctx, model, view);
    }

    public override void Dispose()
    {
        base.Dispose();
    }
}
