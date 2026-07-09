using UnityEngine;
using System;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class RobotView : AView
{
    public event Action<Vector3> EventOnMouseClicked;

    NavMeshAgent navMeshAgent;

    public NavMeshAgent NavMeshAgent => navMeshAgent;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start() 
    { 
        navMeshAgent = GetComponent<NavMeshAgent>();
    }


    void Update()
    {
        if(Input.GetMouseButtonDown(0)) 
            EventOnMouseClicked?.Invoke(Input.mousePosition);
    }   
}
