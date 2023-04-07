using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State
{
    public virtual void Init() {

    }

    public virtual void Enter() {

    } 

    public virtual void Update() {

    }

    public virtual void FixedUpdate() {

    }

    public virtual void LateUpdate() {

    }

    public virtual void Exit() {

    }

    public virtual void HandleCollisionEnter(Collision other) {
        
    }

    public virtual void HandleCollisionStay(Collision other) {
        
    }

    public virtual void HandleCollisionExit(Collision other) {
        
    }

    public virtual void HandleTriggerEnter(Collider other) {
        
    }

    public virtual void HandleTriggerEnter(GameObject detector, Collider other) {
        
    }

    public virtual void HandleTriggerStay(Collider other) {
        
    }

    public virtual void HandleTriggerExit(Collider other) {
        
    }

    public virtual void HandleTriggerExit(GameObject detector, Collider other) {
        
    }
}
