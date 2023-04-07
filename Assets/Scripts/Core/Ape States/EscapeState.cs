using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EscapeState : State
{
    private GameObject ape;
    private ApeController apeController;
    private Escape escape;
    private NavMeshAgent navMeshAgent;
    private MeshRenderer lightBulbRenderer;

    public override void Init() {

    }

    public void Init(GameObject ape) {
        this.Init();
        this.ape = ape; 
        apeController = ape.GetComponent<ApeController>();
        escape = ape.GetComponent<Escape>();
        navMeshAgent = ape.GetComponent<NavMeshAgent>();
        
        MeshRenderer[] mr = ape.GetComponentsInChildren<MeshRenderer>();
        
        foreach (MeshRenderer m in mr) {
            if (m.gameObject.name == "Light Bulb") {
                lightBulbRenderer = m;
                break;
            }
        }
    }

    public override void Enter() {
        lightBulbRenderer.material.color = Color.red;
        Vector3 nextPosition = escape.GetNextEscapePosition().position;
        navMeshAgent.SetDestination(nextPosition);
        navMeshAgent.speed = 5;
    }

    public override void Update() {
        if (navMeshAgent.remainingDistance < 1) {
            Vector3 nextPosition = escape.GetNextEscapePosition().position;
            navMeshAgent.SetDestination(nextPosition);
        }
    }

    public override void Exit() {
        navMeshAgent.speed = 2;
    }

    public override void HandleTriggerEnter(GameObject detector, Collider other) {
        if (detector.name == "Ape Enemy Suspicious") {
            return;
        }
        else if (detector.name == "Ape Enemy Detector") {
            return;
        }
        else if (other.gameObject.transform.parent.name == "Light Sword") {
            Debug.Log("I have got stunned");
        }
        else if (other.gameObject.transform.parent.name == "Ape Net") {
            Debug.Log("I have got catched");
            Camera.main.GetComponent<CameraController>().StartApeCatchedAnimation();
            GameObject.FindObjectOfType<LevelManager>().GetComponent<LevelManager>().ApeCatched();
            GameObject.Destroy(ape);
        }
    }
}
