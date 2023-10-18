using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamageSender : DamageSender
{
    [Header("Enemy")]
    protected EnemyController enemyController;

    private void Awake()
    {
        this.enemyController = GetComponent<EnemyController>();
    }

    protected override void ColliderSendDamage(Collider2D collision)
    {
        base.ColliderSendDamage(collision);

        this.enemyController.damageReceiver.Receive(1);
    }
}
