using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : State
{
    private GameObject player;
    private PlayerController playerController;
    private Animator anim;

    public override void Init() {

    }

    public void Init(GameObject player) {
        this.Init();
        this.player = player;
        playerController = player.GetComponent<PlayerController>();
        anim = player.GetComponent<Animator>();
    }

    public override void Enter() {
        Debug.Log("Enter Attack state");
        
        int equipment = playerController.equipmentController.currentEquipment;

        if (equipment == 0) {
            anim.Play("ApeNetSwipe");
        }
        // Light Sword
        else if (equipment == 1) {
            anim.Play("LightSwordAttack");
        }
    }

    public override void Update() {

    }

    public override void HandleCollisionStay(Collision other) {

    }

    public override void HandleCollisionExit(Collision other) {
    
    }
}
