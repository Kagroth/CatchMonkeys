using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace Core.CircleEnemy
{
    public class AttackState : State
    {
        private GameObject circleEnemy;
        private EnemyController enemyController;
        private NavMeshAgent navMeshAgent;
        private float attackCounter;

        public override void Init() {

        }

        public void Init(GameObject circleEnemy) {
            this.Init();
            this.circleEnemy = circleEnemy; 
            enemyController = circleEnemy.GetComponent<EnemyController>();
            navMeshAgent = circleEnemy.GetComponent<NavMeshAgent>();
        }

        public override void Enter() {
            Vector3 targetDirection = enemyController.target.position - enemyController.transform.position;
            enemyController.transform.rotation = Quaternion.LookRotation(targetDirection);
            enemyController.Attack();
        }

        public override void Update() {
            attackCounter += Time.deltaTime;
            
            if (attackCounter > enemyController.attackTime) {
                attackCounter = 0;
                enemyController.Attack();
            }
        }

        public override void HandleTriggerEnter(Collider other) {
            if (other.gameObject.transform.parent.name == "Light Sword") {
                Debug.Log("I got attacked by Light Sword");
                enemyController.DoDamage(1);
            }
        }

        public override void HandleTriggerExit(GameObject detector, Collider other) {
            if (detector.name == "Enemy Detector") {
                enemyController.stateMachine.ChangeState(enemyController.patrolState);
            }
        }
    }    
}

