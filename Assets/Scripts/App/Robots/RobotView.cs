using UnityEngine;
using System;
using UnityEngine.AI;
using UnityEngine.Assertions;

[RequireComponent(typeof(NavMeshAgent))]
public class RobotView : AView
{
    public event Action<Vector3> EventOnMouseClicked;

    // Raised once when the agent settles at its current destination.
    public event Action EventOnDestinationReached;

    [SerializeField] float arrivalTolerance = 0.2f;

    NavMeshAgent navMeshAgent;

    // Starts true so no arrival fires before the first MoveTo.
    bool destinationReachedNotified = true;

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

        CheckDestinationReached();
    }

    void CheckDestinationReached()
    {
        if(navMeshAgent == null || destinationReachedNotified)
            return;

        // While the path is still being computed remainingDistance is Infinity.
        if(navMeshAgent.pathPending)
            return;

        float stopDistance = Mathf.Max(navMeshAgent.stoppingDistance, arrivalTolerance);
        if(navMeshAgent.remainingDistance > stopDistance)
            return;

        // Reached: either the path is consumed or the agent has effectively stopped.
        if(navMeshAgent.hasPath && navMeshAgent.velocity.sqrMagnitude > 0.0025f)
            return;

        destinationReachedNotified = true;
        EventOnDestinationReached?.Invoke();
    }

    public void LoadCargo(CargoComp cargo)
    {
        Assert.IsNotNull(cargo);

        cargo.transform.SetParent(this.transform,  true);
        cargo.transform.localPosition = new Vector3(.0f, 1.5f, .0f);
    }

    public void MoveTo(Vector3 destination)
    {
        if(navMeshAgent == null)
            return;

        destinationReachedNotified = false;
        navMeshAgent.isStopped = false;
        navMeshAgent.SetDestination(destination);
    }

    public void StopMovement()
    {
        if(navMeshAgent == null)
            return;

        navMeshAgent.isStopped = true;
        navMeshAgent.ResetPath();
    }
}
