using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PatrolState : State
{
    private GameObject ape;
    private ApeController apeController;
    private Patrol patrol;
    private NavMeshAgent navMeshAgent;
    private float patrolCounter;

    public override void Init() {

    }

    public void Init(GameObject ape) {
        this.Init();
        this.ape = ape; 
        apeController = ape.GetComponent<ApeController>();
        patrol = ape.GetComponent<Patrol>();
        navMeshAgent = ape.GetComponent<NavMeshAgent>();
    }

    public override void Enter() {
        Vector3 nextPosition = patrol.GetNextPatrolPosition().position;
        navMeshAgent.SetDestination(nextPosition);
    }

    public override void Update() {
        patrolCounter += Time.deltaTime;

        if (patrolCounter > patrol.GetPatrolTime()) {
            patrolCounter = 0;
            Vector3 nextPosition = patrol.GetNextPatrolPosition().position;
            navMeshAgent.SetDestination(nextPosition);
        }
    }

    public override void Exit() {

    }

    public override void HandleTriggerEnter(GameObject detector, Collider other) {
        if (detector.name == "Ape Enemy Suspicious") {
            apeController.stateMachine.ChangeState(apeController.suspiciousState);
        }
        else if (detector.name == "Ape Enemy Detector") {
            apeController.stateMachine.ChangeState(apeController.escapeState);
        }
        else if (other.gameObject.transform.parent.name == "Light Sword") {
            Debug.Log("I have got stunned");
        }
        else if (other.gameObject.transform.parent.name == "Ape Net") {
            Debug.Log("I have got catched");
            GameObject.FindObjectOfType<LevelManager>().GetComponent<LevelManager>().ApeCatched();
            GameObject.Destroy(ape);
        }
    }
}
