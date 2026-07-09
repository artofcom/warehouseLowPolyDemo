using UnityEngine;
using System;

public class StationView : AView
{
    public event Action<IRobotActor> EventOnRobotArrived;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start() 
    { 
    }


    private void OnTriggerEnter(Collider other)
    {
        Debug.Log($"[OnTriggerEnter] {other.name} has Collied on the station!");

        AView robot = other.GetComponent<AView>();
        if(robot == null)
            return;
        var controller = robot.Controller as RobotController;
        if(controller == null)
            return;

        OnRobotArrived(controller);
    }

    protected virtual void OnRobotArrived(IRobotActor robot)
    {
        Debug.Log($"[Robot Arrived] has Collied on the station!");

        EventOnRobotArrived?.Invoke( robot );
    }

}
