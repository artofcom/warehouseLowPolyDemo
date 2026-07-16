using System.Collections.Generic;

public class MessageController : AController, IMessageHandler
{
    readonly List<IMissionReceiver> receivers = new List<IMissionReceiver>();

    public MessageController(AContext ctx, AModel model, AView view) : base(ctx, model, view)
    {
    }

    public void Register(IMissionReceiver receiver)
    {
        if(receiver != null && !receivers.Contains(receiver))
            receivers.Add(receiver);
    }

    public void Unregister(IMissionReceiver receiver)
    {
        receivers.Remove(receiver);
    }

    public void Dispatch(RobotMission mission)
    {
        if(mission == null)
            return;

        // Single robot for now: forward to every registered receiver.
        for(int q = 0; q < receivers.Count; ++q)
            receivers[q].OnMissionAssigned(mission);
    }
}
