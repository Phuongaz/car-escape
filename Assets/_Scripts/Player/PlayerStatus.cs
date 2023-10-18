using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : MonoBehaviour
{
    protected PlayerController playerController;

    private void Awake()
    {
        this.playerController = GetComponent<PlayerController>();
    }

    public virtual void Dead()
    {
        Debug.Log("Dead");
    }
}
