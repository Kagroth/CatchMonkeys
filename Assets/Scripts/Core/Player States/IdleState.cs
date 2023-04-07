using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : State
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
        Debug.Log("Enter Idle state");
        anim.Play("Idle");
        playerController.isGrounded = true;
        playerController.jumpCounter = 0;
    }

    public override void Update() {
        if (Input.GetKeyDown(KeyCode.Space)) {
            playerController.stateMachine.ChangeState(playerController.jumpState);
        }
        else if (playerController.isGrounded) {
            if (Input.GetKeyDown(KeyCode.P)) {
                if (playerController.equipmentController.currentEquipment == 2) {
                    playerController.stateMachine.ChangeState(playerController.slingshotAimState);
                    return;
                }
                
                playerController.stateMachine.ChangeState(playerController.attackState);
                return;
            }

            float horizontal = Input.GetAxis("Horizontal");
            float vertical = Input.GetAxis("Vertical");

            float translation = vertical * playerController.speed * Time.deltaTime; 
            float rotation = horizontal * playerController.speed * Time.deltaTime * 20;

            playerController.transform.Translate(0, 0, translation);
            playerController.transform.Rotate(0, rotation, 0);
        }
    }

    public override void HandleCollisionStay(Collision other) {
        playerController.isGrounded = true;
        playerController.jumpCounter = 0;
    }

    public override void HandleCollisionExit(Collision other) {
        playerController.isGrounded = false;
    }
}
