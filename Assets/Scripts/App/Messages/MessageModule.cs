public class MessageModule : AModule
{
    public override void Init(AContext ctx)
    {
        var model = new MessageModel();
        controller = new MessageController(ctx, model, view);

        // The message handler is the one shared channel exposed through context.
        ctx.UpdateData("MessageHandler", controller as IMessageHandler);
    }

    public override void Dispose()
    {
        base.Dispose();
    }
}
