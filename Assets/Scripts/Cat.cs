using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Cat : Animal
{
    public float detectionRadius;
    public float stopRadius;
    public Transform normalBehavior;

    public float relationPoints;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindWithTag("Player").transform;
        animator = GetComponent<Animator>();
        animator.SetBool("Idle", true);
    }

    // Update is called once per frame
    void Update()
    {
        DetectPlayer();
    }

    public void DetectPlayer()
    {
        if (Vector3.Distance(target.position, transform.position) <= detectionRadius && Vector3.Distance(target.position, transform.position) > stopRadius)
        {
            checkRelation();
        }
        else
        {
            catIdle();
        }
    }

    private void ChangeDirection(Vector2 direction)
    {
        if (Mathf.Abs(direction.x) > Mathf.Abs(direction.y))
        {

            if (direction.x > 0)
            {
                direction.x = 1;
            }

            else if (direction.x < 0)
            {
                direction.x = -1;
            }

        }
        else if (Mathf.Abs(direction.x) < Mathf.Abs(direction.y))
        {
            if (direction.y > 0)
            {
                direction.y = 1;
            }

            else if (direction.y < 0)
            {
                direction.y = -1;
            }
        }
        catWalk(direction);
    }

    public void checkRelation()
    {
        if (relationPoints <= 0)
        {
            moveAwayFromPlayer();
        }
        else if (relationPoints >= 1)
        {
            followPlayer();
        }
    }

    public void moveAwayFromPlayer()
    {
        Vector3 direction = Vector3.MoveTowards(transform.position, target.position, -1 * moveSpeed * Time.deltaTime);
        ChangeDirection(direction - transform.position);
        rb.MovePosition(direction);
        stopRadius = 0;
    }

    public void followPlayer()
    {
        Vector3 direction = Vector3.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
        ChangeDirection(direction - transform.position);
        rb.MovePosition(direction);
    }

    public void catIdle()
    {
        animator.SetBool("Idle", true);
    }

    public void catWalk(Vector2 direction)
    {
        animator.SetBool("Idle", false);
        animator.SetFloat("Horizontal", direction.x);
        animator.SetFloat("Vertical", direction.y);
        animator.SetFloat("Speed", direction.sqrMagnitude);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;

        Gizmos.DrawLine(transform.position, target.position);

    }

}
