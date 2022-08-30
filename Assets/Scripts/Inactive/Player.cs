﻿//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public enum PlayerState
//{
//    walk,
//    attack,
//    interact,
//    stagger,
//    idle
//}

//public class Player : MonoBehaviour
//{


//    public PlayerState currentState;
//    public float speed;
//    private Rigidbody2D myRigidbody;
//    private Vector3 change;
//    private Animator animator;
//    public FloatValue currentHealth;
//    public Signal playerHealthSignal;
//    public VectorValue startingPosition;
//    public Inventory playerInventory;
//    public SpriteRenderer receivedItemSprite;
//    public Signal playerHit;
//    public Signal reduceMagic;

//    [Header("IFrame Stuff")]
//    public Color flashColor;
//    public Color regularColor;
//    public float flashDuration;
//    public int numberOfFlashes;
//    public Collider2D triggerCollider;
//    public SpriteRenderer mySprite;

//    [Header("Projectile Stuff")]
//    public GameObject projectile;
//    public Item bow;
//    // Use this for initialization
//    void Start()
//    {
//        currentState = PlayerState.walk;
//        animator = GetComponent<Animator>();
//        myRigidbody = GetComponent<Rigidbody2D>();
//        animator.SetFloat("moveX", 0);
//        animator.SetFloat("moveY", -1);
//        transform.position = startingPosition.initialValue;
//    }

//    // Update is called once per frame
//    void Update()
//    {
//        // Is the player in an interaction
//        if (currentState == PlayerState.interact)
//        {
//            return;
//        }
//        change = Vector3.zero;
//        change.x = Input.GetAxisRaw("Horizontal");
//        change.y = Input.GetAxisRaw("Vertical");
//        if (Input.GetButtonDown("attack") && currentState != PlayerState.attack
//           && currentState != PlayerState.stagger)
//        {
//            StartCoroutine(AttackCo());
//        }
//        else if (Input.GetButtonDown("Second Weapon") && currentState != PlayerState.attack
//           && currentState != PlayerState.stagger)
//        {
//            if (playerInventory.CheckForItem(bow))
//            {
//                StartCoroutine(SecondAttackCo());
//            }
//        }
//        else if (currentState == PlayerState.walk || currentState == PlayerState.idle)
//        {
//            UpdateAnimationAndMove();
//        }
//    }

//    private IEnumerator AttackCo()
//    {
//        animator.SetBool("attacking", true);
//        currentState = PlayerState.attack;
//        yield return null;
//        animator.SetBool("attacking", false);
//        yield return new WaitForSeconds(.3f);
//        if (currentState != PlayerState.interact)
//        {
//            currentState = PlayerState.walk;
//        }
//    }

//    private IEnumerator SecondAttackCo()
//    {
//        //animator.SetBool("attacking", true);
//        currentState = PlayerState.attack;
//        yield return null;
//        MakeArrow();
//        //animator.SetBool("attacking", false);
//        yield return new WaitForSeconds(.3f);
//        if (currentState != PlayerState.interact)
//        {
//            currentState = PlayerState.walk;
//        }
//    }

//    private void MakeArrow()
//    {
//        if (playerInventory.currentMagic > 0)
//        {
//            Vector2 temp = new Vector2(animator.GetFloat("moveX"), animator.GetFloat("moveY"));
//            Arrow arrow = Instantiate(projectile, transform.position, Quaternion.identity).GetComponent<Arrow>();
//            arrow.Setup(temp, ChooseArrowDirection());
//            playerInventory.ReduceMagic(arrow.magicCost);
//            reduceMagic.Raise();
//        }
//    }

//    Vector3 ChooseArrowDirection()
//    {
//        float temp = Mathf.Atan2(animator.GetFloat("moveY"), animator.GetFloat("moveX")) * Mathf.Rad2Deg;
//        return new Vector3(0, 0, temp);
//    }


//    public void RaiseItem()
//    {
//        if (playerInventory.currentItem != null)
//        {
//            if (currentState != PlayerState.interact)
//            {
//                animator.SetBool("receive item", true);
//                currentState = PlayerState.interact;
//                receivedItemSprite.sprite = playerInventory.currentItem.itemSprite;
//            }
//            else
//            {
//                animator.SetBool("receive item", false);
//                currentState = PlayerState.idle;
//                receivedItemSprite.sprite = null;
//                playerInventory.currentItem = null;
//            }
//        }
//    }

//    void UpdateAnimationAndMove()
//    {
//        if (change != Vector3.zero)
//        {
//            MoveCharacter();
//            change.x = Mathf.Round(change.x);
//            change.y = Mathf.Round(change.y);
//            animator.SetFloat("moveX", change.x);
//            animator.SetFloat("moveY", change.y);
//            animator.SetBool("moving", true);
//        }
//        else
//        {
//            animator.SetBool("moving", false);
//        }
//    }

//    void MoveCharacter()
//    {
//        change.Normalize();
//        myRigidbody.MovePosition(
//            transform.position + change * speed * Time.deltaTime
//        );
//    }

//    public void Knock(float knockTime, float damage)
//    {
//        currentHealth.RuntimeValue -= damage;
//        playerHealthSignal.Raise();
//        if (currentHealth.RuntimeValue > 0)
//        {
//            playerHit.Raise();
//            StartCoroutine(KnockCo(knockTime));
//        }
//        else
//        {
//            this.gameObject.SetActive(false);
//        }
//    }

//    private IEnumerator KnockCo(float knockTime)
//    {
//        if (myRigidbody != null)
//        {
//            StartCoroutine(FlashCo());
//            yield return new WaitForSeconds(knockTime);
//            myRigidbody.velocity = Vector2.zero;
//            currentState = PlayerState.idle;
//            myRigidbody.velocity = Vector2.zero;
//        }
//    }

//    private IEnumerator FlashCo()
//    {
//        int temp = 0;
//        triggerCollider.enabled = false;
//        while (temp < numberOfFlashes)
//        {
//            mySprite.color = flashColor;
//            yield return new WaitForSeconds(flashDuration);
//            mySprite.color = regularColor;
//            yield return new WaitForSeconds(flashDuration);
//            temp++;
//        }
//        triggerCollider.enabled = true;
//    }
//}
