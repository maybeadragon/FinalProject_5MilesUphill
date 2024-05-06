using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.AI;

public class BasicPatrol : StalkerState
{
    private BasicAgentStateMachine basicAgentStateMachine;
    private List<Transform> waypoints; // List of waypoints specific to this agent
    private int index = 0; 
    private Transform playerTransform;
    private float detectionZone = 30f;

    // Variable to store the index of the current waypoint when exiting patrol state
    private int lastWaypointIndex = 0;

    public BasicPatrol(BasicAgentStateMachine basicPatrol, NavMeshAgent agent, List<Transform> specificWaypoints)
    {
        this.basicAgentStateMachine = basicPatrol;
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        this.waypoints = specificWaypoints;
    }

    public void Enter()
    {
        Debug.Log("Entering Patrol State:");
        index = lastWaypointIndex;
        basicAgentStateMachine.agent.SetDestination(waypoints[index].position);
    }

    public void Execute()
    {
        if (Vector3.Distance(basicAgentStateMachine.agent.transform.position, playerTransform.position) <= detectionZone)
        {
            basicAgentStateMachine.SetState(new BasicPursuit(basicAgentStateMachine, basicAgentStateMachine.agent, waypoints));
        }
        else
        {
            if (basicAgentStateMachine.agent.remainingDistance < 0.5f)
            {
                 // Update the index of the last waypoint visited
                lastWaypointIndex = index;

                index = (index + 1) % waypoints.Count;
                basicAgentStateMachine.agent.SetDestination(waypoints[index].position);
            }
        }
    }



    public void Exit()
    {
        
    }


}
