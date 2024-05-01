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

    public BasicPatrol(BasicAgentStateMachine basicPatrol, NavMeshAgent agent, List<Transform> specificWaypoints)
    {
        this.basicAgentStateMachine = basicPatrol;
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        this.waypoints = specificWaypoints;
    }

    public void Enter()
    {
        index = 0;
        basicAgentStateMachine.agent.SetDestination(waypoints[index].position);
    }

    public void Execute()
    {
        if (Vector3.Distance(basicAgentStateMachine.agent.transform.position, playerTransform.position) <= detectionZone)
        {
            basicAgentStateMachine.SetState(new BasicPursuit(basicAgentStateMachine, basicAgentStateMachine.agent));
        }
        else
        {
            if (basicAgentStateMachine.agent.remainingDistance < 0.5f)
            {
                index = (index + 1) % waypoints.Count;
                basicAgentStateMachine.agent.SetDestination(waypoints[index].position);
            }
        }
    }

    public void Exit()
    {
        // Cleanup code when exiting patrol state
    }


    /*private Transform[] FilterWaypointsOnNavMesh(Transform[] allWaypoints)
    {
        // Filter waypoints that are on the NavMesh
        return allWaypoints.Where(waypoint => IsWaypointOnNavMesh(waypoint.position)).ToArray();
    }


   /*private bool IsWaypointOnNavMesh(Vector3 position)
    {
        NavMeshHit hit;
        if (NavMesh.SamplePosition(position, out hit, 1f, NavMesh.AllAreas))
        {
            float distance = Vector3.Distance(position, hit.position);
            return distance < 1.0f; // Adjust threshold as needed
        }
        return false;
    }*/

}
