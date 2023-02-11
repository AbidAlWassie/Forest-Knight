using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fish : MonoBehaviour
{
    public float fleeRadius;
    public float detectBaitRadius;
    public float waitTime;
    public float startWaitTime;
    public Rigidbody2D rb;
    Vector2 velocity = Vector2.zero;
    public float moveSpeed = 1f;

    void Start()
    {
        velocity = Vector2.zero;
        waitTime = startWaitTime;
        velocity = new Vector2(Random.Range(-1, 2), Random.Range(-1, 2));
    }

    void Update()
    {
        //velocity.x = Input.GetAxisRaw("Horizontal");
        //velocity.y = Input.GetAxisRaw("Vertical");

        fishMove();
        rb.MovePosition(rb.position + velocity.normalized * moveSpeed * Time.fixedDeltaTime);
        //Debug.Log("fish going:" + velocity);
    }

    void fishMove()
    {
        if (waitTime <= 0)
        {
            velocity = new Vector2(Random.Range(-1, 2), Random.Range(-1, 2));
            //Debug.Log(velocity);
            waitTime = startWaitTime;
        }
        else
        {
            waitTime -= Time.deltaTime;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Water"))
        {
            //Debug.Log("Fish hit water " + velocity);
            if (velocity == Vector2.down)
            {
                velocity = Vector2.up;
                //Debug.Log("Fish going down " + Vector2.down);
            }
            else if (velocity == Vector2.up)
            {
                velocity = Vector2.down;
                //Debug.Log("Fish going down " + Vector2.down);
            }
            else if (velocity == Vector2.right)
            {
                velocity = Vector2.left;
                //Debug.Log("Fish going left " + Vector2.left);
            }
            else if (velocity == Vector2.left)
            {
                velocity = Vector2.right;
                //Debug.Log("Fish going right " + Vector2.right);
            }
            //velocity = new Vector2(Random.Range(-1, 1), Random.Range(-1, 1));
        }
    }


}
