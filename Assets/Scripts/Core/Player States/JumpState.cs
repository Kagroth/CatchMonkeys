using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpState : State
{
    private GameObject player;
    private PlayerController playerController;
    private Animator anim;
    private Rigidbody rb;

    public override void Init() {

    }

    public void Init(GameObject player) {
        this.Init();
        this.player = player;
        playerController = player.GetComponent<PlayerController>();
        anim = player.GetComponent<Animator>();
        rb = player.GetComponent<Rigidbody>();
    }

    public override void Enter() {
        Debug.Log("Enter jump state");
        Jump();
    }

    public override void Update() {
        if (Input.GetKeyDown(KeyCode.Space)) {
            Jump();
        }
    }

    private void Jump() {
        Debug.Log("Space pressed");
        if (playerController.jumpCounter < playerController.maxJumpCount) {
            rb.AddForce(playerController.transform.forward * Input.GetAxis("Vertical") * playerController.jumpSpeed / 2, ForceMode.Impulse);
            rb.AddForce(Vector3.up * playerController.jumpSpeed, ForceMode.Impulse);
            playerController.jumpCounter++;
        }
    }

    public override void HandleCollisionEnter(Collision other) {
        Debug.Log("COLLISION");
        playerController.stateMachine.ChangeState(playerController.idleState);
    }
}
