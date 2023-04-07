using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ApeController : MonoBehaviour
{
    public StateMachine stateMachine;
    public PatrolState patrolState;
    public SuspiciousState suspiciousState;
    public EscapeState escapeState;

    // Start is called before the first frame update
    void Start()
    {
        stateMachine = new StateMachine();
        patrolState = new PatrolState();
        suspiciousState = new SuspiciousState();
        escapeState = new EscapeState();

        patrolState.Init(this.gameObject);
        suspiciousState.Init(this.gameObject);
        escapeState.Init(this.gameObject);
        
        stateMachine.Init(patrolState);
    }

    // Update is called once per frame
    void Update()
    {
        stateMachine.Update();
    }

    private void OnTriggerEnter(Collider other) {
        stateMachine.currentState.HandleTriggerEnter(this.gameObject, other);
    }
}
