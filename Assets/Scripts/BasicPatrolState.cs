using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BasicAgentStateMachine : MonoBehaviour
{
    public NavMeshAgent agent;
    public StalkerState currentState;


    private void Awake() 
    {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        var patrol = new BasicPatrol(this, agent);

        SetState(patrol);
    }

    public void SetState(StalkerState newState) 
    {
        currentState?.Exit();
        currentState = newState;
        currentState.Enter();
    }

    private void Update()
    {
        currentState?.Execute();
    }
}
