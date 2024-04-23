using UnityEngine;
using System.Linq; // For LINQ queries

public class StalkerPatrol : StalkerState 
{
    private StalkerStateMachine stateMachine;
    private Transform[] waypoints; //Creates an array that stores the waypoints for the pathfinding
    private int index = 0; //Initialized to the first value in the waypoints array
    private Transform playerTransform;

    private float detectionZone = 20f;
    private float teleportRange = 5f;
    private float teleportationTime = 10f;
    private bool isTeleporting;
    private float lastDetectionTime;

    public StalkerPatrol(StalkerStateMachine stateMachine, UnityEngine.AI.NavMeshAgent agent)
    {
        this.stateMachine = stateMachine;
        waypoints = GameObject.FindGameObjectsWithTag("Waypoint").Select(obj => obj.transform).ToArray();
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }

    public void Enter()
    {
        index = 0;
        stateMachine.stalker.SetDestination(waypoints[index].position);
    }

    public void Execute()
    {
        // Check if the player is in the detection zone
        if (Vector3.Distance(stateMachine.stalker.transform.position, playerTransform.position) <= detectionZone)
        {
            // Transition to ChaseState
            stateMachine.SetState(new StalkerPursuit(stateMachine, stateMachine.stalker));
        }
        else
        {
            // Continue patrolling if the player is not detected
            if (stateMachine.stalker.remainingDistance < 0.5f)
            {
                index = (index + 1) % waypoints.Length;
                stateMachine.stalker.SetDestination(waypoints[index].position);
            }
        }
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
