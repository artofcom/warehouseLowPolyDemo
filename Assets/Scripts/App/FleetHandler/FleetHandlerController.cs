using UnityEngine;

public class FleetHandlerController : AController
{
    FleetHandlerView View;

    int nextMissionId = 1;

    public FleetHandlerController(AContext ctx, AModel model, AView view) : base(ctx, model, view)
    {
        View = view as FleetHandlerView;

        View.EventOnBtnStartClicked += OnBtnStartClicked;
    }

    public void OnBtnStartClicked()
    {
        var handler = context.GetData("MessageHandler") as IMessageHandler;
        if(handler == null)
        {
            Debug.LogWarning("[FleetHandler] MessageHandler not available.");
            return;
        }

        // Build the transport job in code and dispatch it as a message.
        var mission = MissionFactory.CreateTransport(nextMissionId++, StationId.PickUp, StationId.DropOff);
        handler.Dispatch(mission);
    }
}
