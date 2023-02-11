using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.AI;
public class Cat : Animal
{
    public float detectionRadius;
    public float stopRadius;
    public Transform normalBehavior;

    public float relationPoints;

    public Transform[] moveSpot;
    private int randomSpot;
    public float waitTime;
    public float startWaitTime;

    //public NavMeshAgent agent;

    // Start is called before the first frame update
    void Start()
    {
        //agent = GetComponent<NavMeshAgent>();
        //agent.updateRotation = false;
        //agent.updateUpAxis = false;

        target = GameObject.FindWithTag("Player").transform;
        animator = GetComponent<Animator>();
        animator.SetBool("Idle", true);
        randomSpot = Random.Range(0, moveSpot.Length);
        moveSpeed = 20;
    }

    // Update is called once per frame
    void Update()
    {
        DetectPlayer();
    }


    public void DetectPlayer()
    {
        if (Vector3.Distance(target.position, transform.position) <= detectionRadius && Vector3.Distance(target.position, transform.position) >= stopRadius)
        {
            //print(Vector3.Distance(target.position, transform.position));
            checkRelation();
        }

        else if (Vector3.Distance(target.position, transform.position) <= 1.05)
        {
            animator.SetBool("Idle", false);
            animator.SetFloat("Speed", 0);
        }

        else
        {
            catRandomMove();
        }
    }

    private void ChangeDirection(Vector2 direction)
    {
        if (Mathf.Abs(direction.x) > Mathf.Abs(direction.y))
        {

            if (direction.x > 0)
            {
                direction.x = 1;
                direction.y = 0;
            }

            else if (direction.x < 0)
            {
                direction.x = -1;
                direction.y = 0;
            }

        }
        else if (Mathf.Abs(direction.x) < Mathf.Abs(direction.y))
        {
            if (direction.y > 0)
            {
                direction.x = 0;
                direction.y = 1;
            }

            else if (direction.y < 0)
            {
                direction.x = 0;
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

        //agent.SetDestination(-1 * target.position);

        detectionRadius = 10;
        stopRadius = 0;
        moveSpeed = 30;
    }

    public void followPlayer()
    {
        Vector3 direction = Vector3.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
        ChangeDirection(direction - transform.position);
        rb.MovePosition(direction);
        //agent.SetDestination(target.position);
    }

    void catRandomMove()
    {
        if (Vector2.Distance(transform.position, moveSpot[randomSpot].position) < 0.2f)
        {
            if (waitTime <= 0)
            {
                randomSpot = Random.Range(0, moveSpot.Length);
                waitTime = startWaitTime;
                catIdle();
            }
            else
            {
                waitTime -= Time.deltaTime;
                catMove();
            }
        }

        Vector3 direction = Vector2.MoveTowards(transform.position, moveSpot[randomSpot].position, moveSpeed * Time.deltaTime);

        ChangeDirection(direction - transform.position);
        rb.MovePosition(direction);
    }

    public void catIdle()
    {
        animator.SetBool("Idle", true);
    }

    public void catMove()
    {
        animator.SetBool("Idle", false);
    }

    public void catWalk(Vector2 direction)
    {
        animator.SetBool("Idle", false);
        animator.SetFloat("Horizontal", direction.x);
        animator.SetFloat("Vertical", direction.y);
        animator.SetFloat("Speed", direction.sqrMagnitude);
    }

    //private void OnDrawGizmos()
    //{
    //    Gizmos.color = Color.blue;
    //    Gizmos.DrawLine(transform.position, target.position);
    //}

}
