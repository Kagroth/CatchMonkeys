using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraAnimationEvents : MonoBehaviour
{
    // animation event
    public void OnApeCatchAnimationStart() {
        Debug.Log("START");
    }

    // animation event
    public void OnApeCatchAnimationEnd() {
        Debug.Log("END");
    }
}
