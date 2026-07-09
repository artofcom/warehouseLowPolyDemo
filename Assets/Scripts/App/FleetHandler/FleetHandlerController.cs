using UnityEngine;
using UnityEngine.Assertions;

public class FleetHandlerController : AController
{
    FleetHandlerView View;
    public FleetHandlerController(AContext ctx, AModel model, AView view) : base(ctx, model, view)
    {
        View = view as FleetHandlerView;

        View.EventOnBtnStartClicked += OnBtnStartClicked;
    }

    // Dispose() {}

    public void OnBtnStartClicked()
    {
        RobotModule robotModule = context.GetData("Robot") as RobotModule;
        Assert.IsNotNull(robotModule);

        robotModule.StartNavigation();
    }
}
