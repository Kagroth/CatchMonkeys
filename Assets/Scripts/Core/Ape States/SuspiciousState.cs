using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuspiciousState : State
{
    private GameObject ape;
    private ApeController apeController;
    private MeshRenderer lightBulbRenderer;
    private float suspiciousCounter;
    private float suspiciousTime;

    public override void Init() {

    }

    public void Init(GameObject ape) {
        this.Init();
        this.ape = ape; 
        apeController = ape.GetComponent<ApeController>();
        MeshRenderer[] mr = ape.GetComponentsInChildren<MeshRenderer>();
        
        foreach (MeshRenderer m in mr) {
            if (m.gameObject.name == "Light Bulb") {
                lightBulbRenderer = m;
                break;
            }
        }
    }

    public override void Enter() {
        suspiciousCounter = 0f;
        suspiciousTime = 5f;
        lightBulbRenderer.material.color = Color.yellow;
    }

    public override void Update() {
        suspiciousCounter += Time.deltaTime;

        if (suspiciousCounter > suspiciousTime) {
            apeController.stateMachine.ChangeState(apeController.patrolState);
        }
    }

    public override void Exit() {
        lightBulbRenderer.material.color = Color.blue;
    }

    public override void HandleTriggerEnter(GameObject detector, Collider other) {
        if (detector.name == "Ape Enemy Suspicious") {
            return;
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
