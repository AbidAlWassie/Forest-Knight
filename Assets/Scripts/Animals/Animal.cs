using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animal : MonoBehaviour
{
    public float moveSpeed;
    public string petName;

    public Transform target;
    public Animator animator;
    public Rigidbody2D rb;
    public Vector2 movement;


    void Start()
    {
        animator = GetComponent<Animator>();
    }


}
