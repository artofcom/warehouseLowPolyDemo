using UnityEngine;
using System;
using UnityEngine.AI;
using UnityEngine.Assertions;

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

    public void LoadCargo(CargoComp cargo)
    {
        Assert.IsNotNull(cargo);

        cargo.transform.SetParent(this.transform,  true);
        cargo.transform.localPosition = new Vector3(.0f, 1.5f, .0f);
    }
}
