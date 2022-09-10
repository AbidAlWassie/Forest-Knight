using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

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

    Vector2 movement;

    public VectorValue startingPosition;

    // Runs on the first frame
    void Start()
    {
        moveSpeed = 5f;
        currentState = PlayerState.walk;
        transform.position = startingPosition.initialValue;
    }

    // Update is called once per frame
    void Update()
    {

        //Debug.Log(currentState);

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
            Debug.Log(currentState);
        }

        else if (Input.GetButtonDown("Fishing") && currentState == PlayerState.fishing)
        {
            StartCoroutine(ExitFishing());
            Debug.Log(currentState);
        }

        else if (currentState == PlayerState.walk) {
            UpdateAnimation();
        }

        movement = Vector2.zero;
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
    }

    void UpdateAnimation()
    {
        if (movement != Vector2.zero)
        {
            UpdateMovement();

            animator.SetFloat("Horizontal", movement.x);
            animator.SetFloat("Vertical", movement.y);
            animator.SetFloat("Speed", movement.sqrMagnitude);
            animator.SetBool("Moving", true);

            if (Input.GetAxisRaw("Horizontal") == 1 || Input.GetAxisRaw("Horizontal") == -1 || Input.GetAxisRaw("Vertical") == 1 || Input.GetAxisRaw("Vertical") == -1)
            {
                animator.SetFloat("LastHorizontal", Input.GetAxisRaw("Horizontal"));
                animator.SetFloat("LastVertical", Input.GetAxisRaw("Vertical"));
            }
        } 
        else
        {
            animator.SetBool("Moving", false);
        }
    }

    void UpdateMovement()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
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
    }

    private IEnumerator ExitFishing()
    {
        animator.SetBool("Fishing", false);
        yield return null;
        moveSpeed = 5f;
        currentState = PlayerState.walk;
    }

}
