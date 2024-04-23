using UnityEngine;
using UnityEngine.AI; 

public class StalkerStateMachine : MonoBehaviour
{
    public StalkerState currentState;
    public NavMeshAgent stalker;

    private void Awake() 
    {
        stalker = GetComponent<NavMeshAgent>();
        var patrol = new StalkerPatrol(this, stalker);

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
