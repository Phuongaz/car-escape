using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform player;
    public float speed = 50f;
    public float distLimit = 4f;
    public float randomPos = 0;

    private void Awake()
    {
        //this.player = PlayerController.instance.transform;
        this.randomPos = Random.Range(-6, 6);
    }

    private void FixedUpdate()
    {
        this.Follow();
    }

    void Follow()
    {
        Vector3 pos = this.player.position;
        pos.x = this.randomPos;

        Vector3 distance = pos - transform.position;

        if (distance.magnitude >= this.distLimit)
        {
            Vector3 targetPoint = pos - distance.normalized * this.distLimit;

            transform.position = Vector3.MoveTowards(gameObject.transform.position, targetPoint, this.speed * Time.fixedDeltaTime);
        }
    }
}
