using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : MonoBehaviour
{
    [SerializeField] private Transform[] patrolPositions;
    [SerializeField] private float patrolTime;
    private int currentPosition;

    // Start is called before the first frame update
    void Start()
    {
        currentPosition = Random.Range(0, patrolPositions.Length);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Transform GetNextPatrolPosition() {
        currentPosition++;

        if (currentPosition >= patrolPositions.Length) {
            currentPosition = 0;
        }

        return patrolPositions[currentPosition];
    }

    public Transform GetRandomPatrolPosition() {
        int currentPosition = Random.Range(0, patrolPositions.Length);

        return patrolPositions[currentPosition];
    }

    public float GetPatrolTime() {
        return patrolTime;
    }

    private void OnDrawGizmos() {
        if (patrolPositions.Length == 0) {
            return;
        }

        Gizmos.color = Color.blue;

        foreach(Transform patrolPoint in patrolPositions) {
            if (patrolPoint != null) {
                Gizmos.DrawSphere(patrolPoint.position, 0.5f);
            }
        }
    }
}
