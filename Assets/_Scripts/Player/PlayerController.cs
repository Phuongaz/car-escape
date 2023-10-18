using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    static public PlayerController instance;

    public DamageReceiver damageReceiver;
    public PlayerStatus playerStatus;
    private void Awake()
    {
        PlayerController.instance = this;
        this.damageReceiver = GetComponent<DamageReceiver>();
        this.playerStatus = GetComponent<PlayerStatus>();
    }
}
