using UnityEngine;
using UnityEngine.AI; 
using System.Collections.Generic;

public class StalkerStateMachine : MonoBehaviour
{
    public StalkerState currentState;
    public NavMeshAgent stalker;
    public List<Transform> waypoints;
    public Animator animator;

    private void Awake() 
    {
        stalker = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        var patrol = new StalkerPatrol(this, stalker, waypoints);

        SetState(patrol);
    }

    public void SetState(StalkerState newState) 
    {
        //Set the parameter true/false in StalkerAnimatorController, depending on newState
        if (newState is StalkerPatrol) {
            animator.SetBool("Pursuit", false);
            animator.SetBool("Patrol", true);
        }
        else if (newState is StalkerPursuit) {
            animator.SetBool("Pursuit", true);
            animator.SetBool("Patrol", false);
        }
        else {
            animator.SetBool("Pursuit", false);
            animator.SetBool("Patrol", false);
        }

        currentState?.Exit();
        currentState = newState;
        currentState.Enter();
    }

    private void Update()
    {
        currentState?.Execute();
    }
}
