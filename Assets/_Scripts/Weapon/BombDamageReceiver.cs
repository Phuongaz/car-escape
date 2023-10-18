using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombDamageReceiver : DamageReceiver
{

    public override void Receive(int damage)
    {
        base.Receive(damage);
        if(this.IsDead())
        {
            EffectManager.instance.SpawnVFX("Explosion_A", transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }

}
