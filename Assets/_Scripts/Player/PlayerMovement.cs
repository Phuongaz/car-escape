using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    protected Rigidbody2D rb2d;

    public Vector2 velocity = new Vector2(0f, 0f);

    public float horizontal = 0f;
    public float vertical = 0f;

    public float speedUp = 0.5f;
    public float speedDown = 0.5f;
    public float speedMax = 20f;
    public float speedHorizontal = 3f;

    public bool autoRun = false;

    private void Awake()
    {
        this.rb2d = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        this.horizontal = Input.GetAxis("Horizontal");
        this.vertical = Input.GetAxis("Vertical");

        if(this.autoRun)
        {
            this.vertical = 1;
        }
    }

    private void FixedUpdate()
    {
        this.UpdateSpeed();
    }

    protected virtual void UpdateSpeed()
    {
        this.velocity.x = this.horizontal * this.speedHorizontal;

        this.UpdateSpeedUp();
        this.UpdateSpeedDown();

        this.rb2d.MovePosition(this.rb2d.position + this.velocity * Time.fixedDeltaTime);
    }

    protected virtual void UpdateSpeedUp()
    {
        if (this.vertical > 0)
        {
            this.velocity.y += this.speedUp;

            if (this.velocity.y > this.speedMax)
            {
                this.velocity.y = this.speedMax;
            }

            if (transform.position.x < -7 || transform.position.x > 7)
            {
                this.velocity.y = 1f;
                if (this.velocity.y < 3f)
                {
                    this.velocity.y = 3f;
                }
            }
        }
    }

    protected void UpdateSpeedDown()
    {
        if (this.vertical == 0)
        {
            this.velocity.y -= this.speedDown;
            if (this.velocity.y < 0) this.velocity.y = 0;
        }
    }
}
