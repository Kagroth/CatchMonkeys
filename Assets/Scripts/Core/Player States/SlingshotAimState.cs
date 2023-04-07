using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlingshotAimState : State
{
    private GameObject player;
    private PlayerController playerController;
    private Animator anim;
    private GameObject slingshotProjectilePrefab;

    public override void Init() {

    }

    public void Init(GameObject player, GameObject slingshotProjectilePrefab) {
        this.Init();
        this.player = player;
        this.slingshotProjectilePrefab = slingshotProjectilePrefab;
        playerController = player.GetComponent<PlayerController>();
        anim = player.GetComponent<Animator>();
    }

    public override void Enter() {
        Debug.Log("I am in aim mode!");
        playerController.GetComponent<EquipmentView>().ShowSlingshotUI(true);
        Camera.main.GetComponent<CameraController>().SwitchToSlingshotCamera();
    }

    public override void Update() {
        if (Input.GetKeyDown(KeyCode.P)) {
            playerController.stateMachine.ChangeState(playerController.idleState);
            return;
        }

        if (Input.GetKeyDown(KeyCode.Space)) {
            GameObject projectile = GameObject.Instantiate(slingshotProjectilePrefab, player.transform.position + player.transform.forward * 2, player.transform.rotation) as GameObject;
            projectile.GetComponent<Rigidbody>().AddForce(player.transform.forward * 10, ForceMode.Impulse);
        }

        float horizontal = Input.GetAxis("Horizontal");
        float rotation = horizontal * playerController.speed * Time.deltaTime * 20;
        playerController.transform.Rotate(0, rotation, 0);           
    }

    public override void Exit() {
        playerController.GetComponent<EquipmentView>().ShowSlingshotUI(false);
        Camera.main.GetComponent<CameraController>().SwitchToMainCamera();
    }
}
