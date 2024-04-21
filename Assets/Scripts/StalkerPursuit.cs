using UnityEngine;

public class StalkerPursuit : StalkerState
{
    private StalkerStateMachine stateMachine;
    private UnityEngine.AI.NavMeshAgent agent;
    private Transform playerTransform;

    private float fieldOfViewAngle = 90f;
    private float lastDetectionTime;
    private float detectionRange = 10f;

     public StalkerPursuit(StalkerStateMachine stateMachine, UnityEngine.AI.NavMeshAgent agent)
    {
        this.stateMachine = stateMachine;
        this.agent = agent;
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        lastDetectionTime = Time.time;
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
                lastDetectionTime = Time.time; // Update last detection time
                agent.SetDestination(playerTransform.position);
            }
            else
            {
                // Player is not in field of view, switch to patrol mode
                stateMachine.SetState(new StalkerPatrol(stateMachine, agent));
            }
        }
        else
        {
            // Player is out of detection range, switch to patrol mode
            stateMachine.SetState(new StalkerPatrol(stateMachine, agent));
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

     public void Exit()
    {
    }


}
