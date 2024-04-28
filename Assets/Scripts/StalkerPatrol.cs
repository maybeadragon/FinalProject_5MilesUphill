using UnityEngine;
using System.Linq; // For LINQ queries

public class StalkerPatrol : StalkerState 
{
    private StalkerStateMachine stateMachine;
    private UnityEngine.AI.NavMeshAgent agent;
    //private Transform[] waypoints; //Creates an array that stores the waypoints for the pathfinding
    //private int index = 0; //Initialized to the first value in the waypoints array
    private Transform playerTransform;

    private float detectionZone = 20f;
    private float teleportRange = 5f;
    private float teleportationTime = 10f;
    private bool isTeleporting;
    private float lastDetectionTime;
    private float exploreRadius = 10f; // Radius for roaming

    public StalkerPatrol(StalkerStateMachine stateMachine, UnityEngine.AI.NavMeshAgent agent)
    {
        this.stateMachine = stateMachine;
        this.agent = agent;
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }

    public void Enter()
    {
        Roam();
    }

    public void Execute()
    {
        // Check if the player is in the detection zone
        if (Vector3.Distance(stateMachine.stalker.transform.position, playerTransform.position) <= detectionZone)
        {
            // Transition to ChaseState
            stateMachine.SetState(new StalkerPursuit(stateMachine, stateMachine.stalker));
        }
    }

     private void Roam()
    {
        // Select the next waypoint for roaming
        Vector3 nextWaypoint = GetNextRoamingDestination();
        agent.SetDestination(nextWaypoint);
    }

    private Vector3 GetNextRoamingDestination()
    {
        // Heuristic: Favor unexplored areas by selecting a random point within a radius
        Vector3 randomDirection = Random.insideUnitSphere * exploreRadius;
        randomDirection += agent.transform.position;
        UnityEngine.AI.NavMeshHit hit;
        UnityEngine.AI.NavMesh.SamplePosition(randomDirection, out hit, exploreRadius, 1);
        return hit.position;
    }

    public void TeleportNearPlayer()
    {
        Vector3 randomOffset = Random.insideUnitSphere * teleportRange;
        randomOffset.y = 0;
        stateMachine.stalker.Warp(playerTransform.position + randomOffset);
        isTeleporting = true;
        lastDetectionTime = Time.time;
    }

    public void Exit()
    {
        
    }

}
