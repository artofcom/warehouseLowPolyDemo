using UnityEngine;
using System;

public class PickupStationView : StationView
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    protected override void OnRobotArrived(IRobotActor robot)
    {
        Debug.Log($"[PIckUpStation] has Collied on the station!");
        
        base.OnRobotArrived(robot);

        // robot.PickUp();
    }
}
