using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core.CircleEnemy;
using Cinemachine;

public class EnemyController : MonoBehaviour
{
    public StateMachine stateMachine;
    public Core.CircleEnemy.PatrolState patrolState;
    public Core.CircleEnemy.AttackState attackState;
    public Core.CircleEnemy.DeathState deathState;
    public Transform target;

    [SerializeField] private int health;
    [SerializeField] public float attackTime;
    [SerializeField] private GameObject projectilePrefab;

    // Start is called before the first frame update
    void Start()
    {
        stateMachine = new StateMachine();
        patrolState = new Core.CircleEnemy.PatrolState();
        attackState = new Core.CircleEnemy.AttackState();
        deathState = new Core.CircleEnemy.DeathState();

        patrolState.Init(this.gameObject);
        attackState.Init(this.gameObject);
        deathState.Init(this.gameObject);

        stateMachine.Init(patrolState);
    }

    // Update is called once per frame
    void Update()
    {
        stateMachine.Update();
    }

    public void DoDamage(int damagePoints) {
        this.health -= damagePoints;

        if (this.health <= 0) {
            stateMachine.ChangeState(deathState);
            return;
        }

        Debug.Log("Now I have: " + health + " health points");
    }

    public void Attack() {
        GameObject prefab = Instantiate(projectilePrefab, transform.position + transform.forward, transform.rotation) as GameObject;
        prefab.GetComponent<Rigidbody>().AddForce(transform.forward * 10, ForceMode.Impulse);
    }

    private void Die() {
        Debug.Log("I have got killed");
        Destroy(this.gameObject);
    }

    private void OnTriggerEnter(Collider other) {
        stateMachine.currentState.HandleTriggerEnter(other);
    }
}
