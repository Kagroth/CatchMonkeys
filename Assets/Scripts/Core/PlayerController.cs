using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] public int health;
    [SerializeField] public float speed;
    [SerializeField] public float jumpSpeed;
    [SerializeField] public bool isGrounded;
    [SerializeField] public int maxJumpCount;
    [SerializeField] private GameObject slingshotProjectilePrefab;

    public StateMachine stateMachine;
    public IdleState idleState;
    public JumpState jumpState;
    public AttackState attackState;
    public SlingshotAimState slingshotAimState;
    public int jumpCounter;

    private Animator anim;
    public EquipmentController equipmentController;
    private HealthView healthView;

    // Start is called before the first frame update
    void Start()
    {
        stateMachine = new StateMachine();
        idleState = new IdleState();
        jumpState = new JumpState();
        attackState = new AttackState();
        slingshotAimState = new SlingshotAimState();

        idleState.Init(this.gameObject);
        jumpState.Init(this.gameObject);
        attackState.Init(this.gameObject);
        slingshotAimState.Init(this.gameObject, slingshotProjectilePrefab);

        stateMachine.Init(idleState);

        anim = GetComponent<Animator>();
        equipmentController = GetComponent<EquipmentController>();
        healthView = GetComponent<HealthView>();
        healthView.Init(health);
    }

    // Update is called once per frame
    void Update()
    {
        stateMachine.Update();
    }

    public void TakeDamage(int damage) {
        health -= damage;

        if (health <= 0) {
            health = 0;
            Debug.Log("Player has died");
        }

        healthView.SetHealth(health);
    }

    private void OnAnimationEnd() {
        stateMachine.ChangeState(idleState);
    }

    private void OnCollisionEnter(Collision other) {
        stateMachine.currentState.HandleCollisionEnter(other);
    }

    private void OnCollisionStay(Collision other) {
        stateMachine.currentState.HandleCollisionStay(other);
    }

    private void OnCollisionExit(Collision other) {
        stateMachine.currentState.HandleCollisionExit(other);
    }
}
