using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamageReceiver : DamageReceiver
{
    protected PlayerController playerController;

    private void Awake()
    {
        this.playerController = GetComponent<PlayerController>();
    }

    public override void Receive(int damage)
    {
        base.Receive(damage);
        if(this.IsDead())
        {
            this.playerController.playerStatus.Dead();
            UIManager.instance.btnGameOver.SetActive(true);
        }
    }
}
