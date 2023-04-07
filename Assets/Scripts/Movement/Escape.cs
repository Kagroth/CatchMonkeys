using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Escape : MonoBehaviour
{
    [SerializeField] private Transform[] escapePathPoints;
    private int currentEscapePoint;

    // Start is called before the first frame update
    void Start()
    {
        currentEscapePoint = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Transform GetNextEscapePosition() {
        currentEscapePoint++;

        if (currentEscapePoint >= escapePathPoints.Length) {
            currentEscapePoint = 0;
        }

        return escapePathPoints[currentEscapePoint];
    }

    private void OnDrawGizmos() {
        if (escapePathPoints.Length == 0) {
            return;
        }

        Gizmos.color = Color.red;
        
        foreach(Transform escapePoint in escapePathPoints) {
            if (escapePoint != null) {
                Gizmos.DrawSphere(escapePoint.position, 0.5f);
            }
        }
    }
}
