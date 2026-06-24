using UnityEngine;
using System.Collections.Generic;
using UnityEngine.Assertions;

public class AppModule : AModule
{
    protected AContext context;
    
    [SerializeField] Camera mainCam;
    [SerializeField] List<AModule> modules;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        this.Init(new Context());

        context.UpdateData("MainCam", mainCam);

        Assert.IsNotNull(modules);
        Assert.IsTrue(modules.Count > 0);
    }

    private void OnDestroy()
    {
        this.Dispose();
    }

    public override void Init(AContext ctx)
    {
        context = ctx;
        var model = new AppModel();
        controller = new AppController(context, model, view);

        for(int q = 0; q < modules.Count; q++) 
            modules[q].Init(ctx);
    }
    public override void Dispose()
    {
        base.Dispose();

        context = null;

        for(int q = 0; q < modules.Count; q++) 
            modules[q].Dispose();
    }
}
