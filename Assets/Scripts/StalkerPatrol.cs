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
    //private HashSet<Transform> exploredWaypoints = new HashSet<Transform>();
    private float waypointSpacing = 50f; // Spacing between generated waypoints


    private float detectionZone = 60f;
    private float teleportRange = 40f;
    private float teleportationTime = 10f;
    private float teleportCooldown = 20f;
    private bool isTeleporting;
    private float lastDetectionTime;
    private float exploreRadius = 300f; // Radius for roaming
    

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
            isTeleporting = false; //Do not teleport while in chase state

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

     public void Roam()
    {
         // Calculate A* path to the player's position
        NavMeshPath path = new NavMeshPath();
        if (NavMesh.CalculatePath(agent.transform.position, playerTransform.position, NavMesh.AllAreas, path))
       {
        // Set the AI's destination to the last waypoint of the calculated path if a valid path is found
        if (path.corners.Length > 0)
        {
            Vector3 lastWaypoint = path.corners[path.corners.Length - 1];
            agent.SetDestination(lastWaypoint);
        }
    }
    
     }

     public void TeleportNearPlayer() //Teleport the agent towards the players location
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

    

