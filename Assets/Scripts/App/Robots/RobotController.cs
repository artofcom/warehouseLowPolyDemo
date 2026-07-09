using UnityEngine;
using UnityEngine.Assertions;

public class RobotController : AController, IRobotActor
{
    RobotView View;
    Camera mainCam;

    public RobotController(AContext ctx, AModel model, AView view) : base(ctx, model, view)
    {
        View = view as RobotView;   
    }

    protected override void OnViewEnabled()
    {
        View.EventOnMouseClicked += OnMouseClicked;
    }

    protected override void OnViewDisabled() 
    {
        View.EventOnMouseClicked -= OnMouseClicked;
    }


    void OnMouseClicked(Vector3 vPos)
    {
        Debug.Log("[Robot] Mouse Clicked...");

        if(mainCam == null)
        {
            mainCam = context.GetData("MainCam") as Camera;
            Assert.IsNotNull(mainCam);
        }

        Ray ray = mainCam.ScreenPointToRay(vPos);
        RaycastHit hit;
        if(Physics.Raycast(ray, out hit))
        {
            View.NavMeshAgent.SetDestination(hit.point);
        }
    }

    public void StartNavigation()
    {
        View.NavMeshAgent.SetDestination(new Vector3(-5.16f, 0.43f, 3.93f));
    }

    public void PickUp() 
    { 
        Debug.Log("[RobotCtrler] Picking Up......");
    } 
    public void DropDown() 
    {
        Debug.Log("[RobotCtrler] Drop Down.....");
    }
}
