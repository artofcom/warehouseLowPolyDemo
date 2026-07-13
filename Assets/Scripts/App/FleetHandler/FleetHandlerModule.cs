using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class FleetHandlerModule : AModule
{   
    [SerializeField] RobotModule robotModule;
    [SerializeField] List<StationModule> stationModules;


    Context context;
    public override void Init(AContext ctx)
    {
        context = ctx as Context;
        ctx.UpdateData("Robot", robotModule);
        var model = new FleetHandlerModel();
        controller = new FleetHandlerController(ctx, model, view);
        
        DeferedInit();
    }

    async void DeferedInit()
    {
        await Task.Delay(100);

        context.UpdateData("PickUpStationPos", stationModules[0].GetViewPosition());
        context.UpdateData("DropOffStationPos", stationModules[1].GetViewPosition());
    }

    public override void Dispose()
    {
        base.Dispose();
    }
}
