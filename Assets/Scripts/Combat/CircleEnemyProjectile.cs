using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleEnemyProjectile : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision other) {
        if (other.gameObject.name.Contains("Player")) {
            Debug.Log("Player shooted!");
            other.gameObject.GetComponent<PlayerController>().TakeDamage(1);
        }

        Destroy(this.gameObject);
    }

    private void OnTriggerExit(Collider other) {
        if (other.gameObject.name.Contains("Level")) {
            Destroy(this.gameObject);
        }
    }
}
