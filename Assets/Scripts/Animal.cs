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


    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


}
