using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Rigidbody2D))]
public class CharacterController2D : MonoBehaviour
{
    Rigidbody2D rigidbody2d;
    [SerializeField] float speed = 2f;
    [SerializeField] bool hasVerticalAnimations = false; // makes anims look better on diagonal movement
    Vector2 motionVector;

    // below used for animations
    public Vector2 lastMotionVector; 
    Animator animator;
    public bool moving;

    void Awake()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        rigidbody2d.gravityScale = 0; // ensure no gravity, our game is 2D
    }

    private void Update()
    {
        // get 2d components, construct vector
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        motionVector = new Vector2(horizontal, vertical);

        // update animator
        animator.SetFloat("horizontal", horizontal);

        // if no vertical animations, then suppress vertical vector if moving horizontally
        if (horizontal != 0 && !hasVerticalAnimations)
            animator.SetFloat("vertical", 0.0f);
        else
            animator.SetFloat("vertical", vertical);
            
        moving = horizontal != 0 || vertical != 0;
        animator.SetBool("moving", moving);

        // if player is moving, then save the vector and update animator
        if (moving)
        {
            lastMotionVector = new Vector2(horizontal, vertical).normalized;

            animator.SetFloat("lastHorizontal", horizontal);
            animator.SetFloat("lastVertical", vertical);
        }
    }

    void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        // set object's velocity
        rigidbody2d.velocity = motionVector * speed;
    }
}
