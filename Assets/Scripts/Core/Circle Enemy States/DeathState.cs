using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Core.CircleEnemy {
    public class DeathState : State
    {
        private GameObject circleEnemy;
        private EnemyController enemyController;
        private Animator anim;

        public override void Init() {

        }

        public void Init(GameObject circleEnemy) {
            this.Init();
            this.circleEnemy = circleEnemy; 
            enemyController = circleEnemy.GetComponent<EnemyController>();
            anim = circleEnemy.GetComponent<Animator>();
        }

        public override void Enter() {
            anim.enabled = true;
            anim.Play("Death");
        }
    }
}

