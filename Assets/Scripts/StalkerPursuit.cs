using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using System;

public class StalkerPursuit : StalkerState
{
    private StalkerStateMachine stateMachine;
    private UnityEngine.AI.NavMeshAgent agent;
    private Transform playerTransform;
    private List<Transform> waypoints; // List of waypoints for patrolling

    private float fieldOfViewAngle = 90f;
    private float detectionRange = 100f;

    private float avoidanceDistance = 8f; // Distance at which the agent starts avoiding obstacles
    private float avoidanceForce = 10f; // Magnitude of the steering force applied to avoid obstacles
    private float distanceThreshold = 5f;


    public static event Action grounded;

     public StalkerPursuit(StalkerStateMachine stateMachine, UnityEngine.AI.NavMeshAgent agent, List<Transform> waypoints)
    {
        this.stateMachine = stateMachine;
        this.agent = agent;
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        this.waypoints = waypoints;
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
                stateMachine.SetState(new StalkerPatrol(stateMachine, agent, waypoints));
            }
        }
        else
        {
            // Player is out of detection range, switch to patrol mode
            stateMachine.SetState(new StalkerPatrol(stateMachine, agent, waypoints));
        }

        float distance = Vector3.Distance(agent.transform.position, playerTransform.position);

        if (distance <= distanceThreshold)
        {
            grounded?.Invoke();
        }

        Steer();

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




    private void Steer()
    {
        RaycastHit hit;
        if (Physics.Raycast(agent.transform.position, agent.transform.forward, out hit, avoidanceDistance))
        {
            // Calculate steering force based on the distance to the obstacle
            float steerFactor = Mathf.Clamp01(1 - (hit.distance / avoidanceDistance));
            Vector3 avoidanceDirection = Vector3.Cross(hit.normal, Vector3.up);
            Vector3 steerForce = avoidanceDirection * avoidanceForce * steerFactor;

            // Apply steering force to adjust the agent's direction
            agent.velocity += steerForce * Time.deltaTime;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Check if the collider is the player
        if (other.CompareTag("Player"))
        {
           grounded?.Invoke();
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
