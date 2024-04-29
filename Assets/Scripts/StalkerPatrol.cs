using UnityEngine;
using System.Linq; // For LINQ queries
using UnityEngine.AI;
using System.Collections.Generic;

public class StalkerPatrol : StalkerState 
{
    private StalkerStateMachine stateMachine;
    private UnityEngine.AI.NavMeshAgent agent;
    //private Transform[] waypoints; //Creates an array that stores the waypoints for the pathfinding
    //private int index = 0; //Initialized to the first value in the waypoints array
    private Transform playerTransform;
    public List<Transform> waypoints; //A list of waypoints for the AI to explore
    private HashSet<Transform> exploredWaypoints = new HashSet<Transform>();


    private float detectionZone = 50f;
    private float teleportRange = 5f;
    private float teleportationTime = 10f;
    private float teleportCooldown = 20f;
    private bool isTeleporting;
    private float lastDetectionTime;
    private float exploreRadius = 50f; // Radius for roaming

    public StalkerPatrol(StalkerStateMachine stateMachine, UnityEngine.AI.NavMeshAgent agent,  List<Transform> waypoints)
    {
        this.stateMachine = stateMachine;
        this.agent = agent;
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        lastDetectionTime = Time.time;
        this.waypoints = waypoints;
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
            stateMachine.SetState(new StalkerPursuit(stateMachine, stateMachine.stalker, waypoints));
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
       // Vector3 nextWaypoint = GetNextRoamingDestination();
        //agent.SetDestination(nextWaypoint);
        Transform nextDestination = SelectNextDestination();
        if (nextDestination != null)
        {
            agent.SetDestination(nextDestination.position);
        }

        
    }

    private Transform SelectNextDestination() //Use A* pathfinding to find next waypoint using scoring system
    {
        // Calculate exploration scores for each waypoint
        Dictionary<Transform, float> explorationScores = new Dictionary<Transform, float>();
        foreach (Transform waypoint in waypoints)
        {
            float explorationScore = GetExplorationScore(waypoint);
            explorationScores.Add(waypoint, explorationScore);
        }

        // Sort waypoints by exploration score (higher scores first)
        List<Transform> sortedWaypoints = new List<Transform>(explorationScores.Keys);
        sortedWaypoints.Sort((a, b) => explorationScores[b].CompareTo(explorationScores[a]));

        // Select the next destination from sorted waypoints
        foreach (Transform waypoint in sortedWaypoints)
        {
            if (!exploredWaypoints.Contains(waypoint))
            {
                return waypoint;
            }
        }

        // If all waypoints have been explored, return null
        return null;
    }

    private float GetExplorationScore(Transform waypoint)
    {
        // Calculate exploration score based on exploration status of the waypoint
        return exploredWaypoints.Contains(waypoint) ? 0f : 1f;
    }

    // Call this method when the AI reaches a waypoint to mark it as explored
    public void MarkWaypointExplored(Transform waypoint)
    {
        exploredWaypoints.Add(waypoint);
    }

    /*private Vector3 GetNextRoamingDestination()
    {
        // Heuristic: Favor unexplored areas by selecting a random point within a radius
        Vector3 randomDirection = Random.insideUnitSphere * exploreRadius;
        randomDirection += agent.transform.position;
        UnityEngine.AI.NavMeshHit hit;
        UnityEngine.AI.NavMesh.SamplePosition(randomDirection, out hit, exploreRadius, 1);
        return hit.position;
    }*/

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
