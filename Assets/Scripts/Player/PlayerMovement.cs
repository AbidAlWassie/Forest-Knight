using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //public int RandNum;

    public enum PlayerState
    {
        idle,
        walk,
        interact,
        attack,
        fishing
    }

    public PlayerState currentState;

    public float moveSpeed;

    public Rigidbody2D rb;
    public Animator animator;

    Vector2 velocity;

    public VectorValue startingPosition;

    // Runs on the first frame
    void Start()
    {
        moveSpeed = 5f;
        currentState = PlayerState.walk;
        transform.position = startingPosition.initialValue;
        velocity = Vector2.down;
    }

    // Runs on every frame
    void Update()
    {
        //RandNum = Random.Range(-1, 2);
        //Debug.Log(RandNum);
        if (currentState == PlayerState.interact)
        {
            return;
        }


        else if (Input.GetButtonDown("Attack") && currentState != PlayerState.attack && currentState != PlayerState.fishing) {
            StartCoroutine(PlayerAttack());
            Debug.Log(currentState);
        }

        else if (Input.GetButtonDown("Fishing") && currentState != PlayerState.fishing) {
            StartCoroutine(EnterFishing());
        }

        else if (Input.GetButtonDown("Fishing") && currentState == PlayerState.fishing)
        {
            StartCoroutine(ExitFishing());
        }

        else if (currentState == PlayerState.walk) {
            UpdateAnimation();
        }

        velocity = Vector2.zero;
        velocity.x = Input.GetAxisRaw("Horizontal");
        velocity.y = Input.GetAxisRaw("Vertical");
    }


    void UpdateAnimation()
    {
        if (velocity != Vector2.zero)
        {
            UpdateMovement();

            animator.SetFloat("Horizontal", velocity.x);
            animator.SetFloat("Vertical", velocity.y);
            animator.SetFloat("Speed", velocity.sqrMagnitude);
            animator.SetBool("Moving", true);
        } 
        else
        {
            animator.SetBool("Moving", false);
        }
    }

    void UpdateMovement()
    {
        rb.MovePosition(rb.position + velocity.normalized * moveSpeed * Time.fixedDeltaTime);
    }

    private IEnumerator PlayerAttack()
    {
        animator.SetBool("Attacking", true);
        moveSpeed = 0;
        currentState = PlayerState.attack;
        yield return null;
        animator.SetBool("Attacking", false);
        yield return new WaitForSeconds(.6f);
        moveSpeed = 5f;
        currentState = PlayerState.walk;
    }

    private IEnumerator EnterFishing()
    {
        animator.SetBool("Fishing", true);
        moveSpeed = 0;
        currentState = PlayerState.fishing;
        yield return null;
        animator.SetBool("Fishing", false);
        yield return new WaitForSeconds(.6f);
        moveSpeed = 5f;
        currentState = PlayerState.walk;
    }

    private IEnumerator EnterFishingAndStay()
    {
        animator.SetBool("Fishing", true);
        moveSpeed = 0;
        currentState = PlayerState.fishing;
        yield return null;
    }

    private IEnumerator ExitFishing()
    {
        animator.SetBool("Fishing", false);
        moveSpeed = 5f;
        currentState = PlayerState.walk;
        yield return null;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Water"))
        {
            //print(collision.CompareTag("Water") + " Entered fishing state");
            StartCoroutine(EnterFishingAndStay());
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Water"))
        {
            //print("Exiting fishing state");
        }
    }

}
