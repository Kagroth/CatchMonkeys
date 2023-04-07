using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace Core.CircleEnemy {
    public class PatrolState : State
    {
        private GameObject circleEnemy;
        private EnemyController enemyController;
        private Patrol patrol;
        private Animator anim;
        private NavMeshAgent navMeshAgent;
        private float patrolCounter;

        public override void Init() {

        }

        public void Init(GameObject circleEnemy) {
            this.Init();
            this.circleEnemy = circleEnemy; 
            enemyController = circleEnemy.GetComponent<EnemyController>();
            patrol = circleEnemy.GetComponent<Patrol>();
            navMeshAgent = circleEnemy.GetComponent<NavMeshAgent>();
        }

        public override void Enter() {
            Debug.Log("Circle Enemy: Patrol state");
            Vector3 nextPosition = patrol.GetRandomPatrolPosition().position;
            navMeshAgent.SetDestination(nextPosition);
        }

        public override void Update() {
            patrolCounter += Time.deltaTime;

            if (patrolCounter > patrol.GetPatrolTime()) {
                patrolCounter = 0;
                Vector3 nextPosition = patrol.GetRandomPatrolPosition().position;
                navMeshAgent.SetDestination(nextPosition);
            }
        }

        public override void Exit() {

        }

        public override void HandleTriggerEnter(Collider other) {
            if (other.gameObject.transform.parent.name == "Light Sword") {
                Debug.Log("I got attacked by Light Sword");
                enemyController.DoDamage(1);
            }
        }

        public override void HandleTriggerEnter(GameObject detector, Collider other) {
            if (detector.name == "Enemy Detector") {
                if (other.gameObject.name == "Player") {
                    enemyController.stateMachine.ChangeState(enemyController.attackState);
                }
            }
        }
    }
}
