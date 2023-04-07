using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApeEnemySuspicious : MonoBehaviour
{
    private ApeController apeController;

    // Start is called before the first frame update
    void Start()
    {
        apeController = GetComponentInParent<ApeController>();    
    }

    private void OnTriggerEnter(Collider other) {
        apeController.stateMachine.currentState.HandleTriggerEnter(this.gameObject, other);
    }
}
