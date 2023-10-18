using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamageReceiver : DamageReceiver
{
    [Header("Enemy")]
    public EnemyController enemyController;

    private void Awake()
    {
        this.enemyController = GetComponent<EnemyController>();
    }

    private void Reset()
    {
        this.hp = 3;
    }

    public override void Receive(int damage)
    {
        base.Receive(damage);
        if(this.IsDead())
        {
            this.enemyController.despawner.Despawn();
        }
    }

}
