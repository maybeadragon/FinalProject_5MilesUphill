using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class BasicPatrol : StalkerState
{
   private BasicAgentStateMachine basicAgentStateMachine;
    private Transform[] waypoints; //Creates an array that stores the waypoints for the pathfinding
    private int index = 0; //Initialized to the first value in the waypoints array
    private Transform playerTransform;

    private float detectionZone = 20f;
   

   
   public BasicPatrol(BasicAgentStateMachine basicPatrol, UnityEngine.AI.NavMeshAgent agent)
    {
        this.basicAgentStateMachine = basicPatrol;
        waypoints = GameObject.FindGameObjectsWithTag("Waypoint").Select(obj => obj.transform).ToArray();
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;

    }


    public void Enter()
    {
        index = 0;
        basicAgentStateMachine.agent.SetDestination(waypoints[index].position);
    }

    public void Execute()
    {
        // Check if the player is in the detection zone
        if (Vector3.Distance(basicAgentStateMachine.agent.transform.position, playerTransform.position) <= detectionZone)
        {
            // Transition to ChaseState
            basicAgentStateMachine.SetState(new BasicPursuit(basicAgentStateMachine, basicAgentStateMachine.agent));
        }
        else
        {
            // Continue patrolling if the player is not detected
            if (basicAgentStateMachine.agent.remainingDistance < 0.5f)
            {
                index = (index + 1) % waypoints.Length;
                basicAgentStateMachine.agent.SetDestination(waypoints[index].position);
            }
        }
    }




    public void Exit()
    {
        
    }
}
