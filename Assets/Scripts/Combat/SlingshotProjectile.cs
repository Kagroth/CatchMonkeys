using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlingshotProjectile : MonoBehaviour
{
    private void OnCollisionEnter(Collision other) {
        if (other.gameObject.name.Contains("Enemy")) {
            Debug.Log("Enemy shooted!");
            other.gameObject.GetComponent<EnemyController>().DoDamage(1);
        }

        Destroy(this.gameObject);
    }

    private void OnTriggerExit(Collider other) {
        if (other.gameObject.name.Contains("Level")) {
            Destroy(this.gameObject);
        }
    }
}
