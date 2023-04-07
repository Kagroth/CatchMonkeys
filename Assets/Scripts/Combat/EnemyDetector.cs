using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDetector : MonoBehaviour
{
    private EnemyController enemyController;

    // Start is called before the first frame update
    void Start()
    {
        enemyController = GetComponentInParent<EnemyController>();    
    }

    private void OnTriggerEnter(Collider other) {
        enemyController.target = other.gameObject.transform;
        enemyController.stateMachine.currentState.HandleTriggerEnter(this.gameObject, other);
        /* if (other.gameObject.name == "Player") {
            Debug.Log("Player Detected!");
            enemyController.Attack(other.gameObject.transform, other.gameObject.GetComponent<PlayerController>());
        } */
    }

    private void OnTriggerExit(Collider other) {
        enemyController.stateMachine.currentState.HandleTriggerExit(this.gameObject, other);
    }
}
