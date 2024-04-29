using UnityEngine;
using System.Linq; // For LINQ queries

public class StalkerPatrol : StalkerState 
{
    private StalkerStateMachine stateMachine;
    private UnityEngine.AI.NavMeshAgent agent;
    //private Transform[] waypoints; //Creates an array that stores the waypoints for the pathfinding
    //private int index = 0; //Initialized to the first value in the waypoints array
    private Transform playerTransform;

    private float detectionZone = 50f;
    private float teleportRange = 5f;
    private float teleportationTime = 10f;
    private float teleportCooldown = 20f;
    private bool isTeleporting;
    private float lastDetectionTime;
    private float exploreRadius = 50f; // Radius for roaming

    public StalkerPatrol(StalkerStateMachine stateMachine, UnityEngine.AI.NavMeshAgent agent)
    {
        this.stateMachine = stateMachine;
        this.agent = agent;
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        lastDetectionTime = Time.time;
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
            lastDetectionTime = Time.time;
            isTeleporting = false;

        }

        else
        {
            Roam();

            // Check if it's time to teleport
            if (!isTeleporting && Time.time - lastDetectionTime >= teleportCooldown)
            {
                TeleportNearPlayer();
            }

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
        randomOffset.y = 0; //Done to prevent vertical movement by AI
        stateMachine.stalker.Warp(playerTransform.position + randomOffset);
        isTeleporting = true;
        lastDetectionTime = Time.time;
        
    }

    public void Exit()
    {
        
    }

}
