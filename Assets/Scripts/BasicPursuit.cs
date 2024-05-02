using System;
using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class BasicPursuit : StalkerState
{
   private BasicAgentStateMachine stateMachine;
    private UnityEngine.AI.NavMeshAgent agent;
    private Transform playerTransform;
    private List<Transform> waypoints;

    private float fieldOfViewAngle = 90f;

    private float detectionRange = 15f;
    private float distanceThreshold = 5f;

    public static event Action agentGameOver;

   

    public BasicPursuit(BasicAgentStateMachine stateMachine, UnityEngine.AI.NavMeshAgent agent)
    {
        this.stateMachine = stateMachine;
        this.agent = agent;
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        
    }

    public void Enter()
    {
        Debug.Log("Entering Pursuit State");
    }

    public void Execute()
    {
        // Check if the player is within detection range
        if (Vector3.Distance(agent.transform.position, playerTransform.position) <= detectionRange)
        {
            // Check if the player is within the stalker's field of view
            if (IsPlayerInFieldOfView())
            {
                
                agent.SetDestination(playerTransform.position);
            }
            else
            {
                // Player is not in field of view, switch to patrol mode
                stateMachine.SetState(new BasicPatrol(stateMachine, agent, waypoints));
            }
        }
        /*else
        {
            // Player is out of detection range, switch to patrol mode
            stateMachine.SetState(new BasicPatrol(stateMachine, agent, waypoints));
        }*/

        float distance = Vector3.Distance(agent.transform.position, playerTransform.position);

        if (distance <= distanceThreshold)
        {
            agentGameOver?.Invoke();
        }

        

    }
    private bool IsPlayerInFieldOfView()
    {
        Vector3 directionToPlayer = playerTransform.position - agent.transform.position;
        float angleToPlayer = Vector3.Angle(agent.transform.forward, directionToPlayer);
        
        if (angleToPlayer <= fieldOfViewAngle * 0.5f)
        {
            RaycastHit hit;
            if (Physics.Raycast(agent.transform.position, directionToPlayer, out hit, detectionRange))
            {
                if (hit.collider.CompareTag("Player"))
                {
                    return true;
                }
            }
        }

        return false;
    }

    private void OnTriggerEnter(Collider other)
    {
        // Check if the collider is the player
        if (other.CompareTag("Player"))
        {
            // Call the game over function
            //controller.Fail();
        }
    }

    // Function to handle game over
    private void GameOver()
    {
        // Show game over screen or trigger game over logic
        Debug.Log("Game Over");
    }
    

     public void Exit()
    {
    }


}