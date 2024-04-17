using UnityEngine;

public class StalkerPursuit : StalkerState
{
    private StalkerStateMachine stateMachine;
    private UnityEngine.AI.NavMeshAgent agent;
    private Transform playerTransform;

     public StalkerPursuit(StalkerStateMachine stateMachine, UnityEngine.AI.NavMeshAgent agent)
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
        //If a player is found, move the AI over the player's current position
        if (playerTransform != null)
        {
            agent.SetDestination(playerTransform.position);
        }
    }

     public void Exit()
    {
    }


}
