using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Transform player;
    public float moveSpeed = 1f;
    private Rigidbody2D rb;
    private Vector2 movement;
    private Animator anim;
    private string walkAnimation = "walk";

    private void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        anim = this.GetComponent<Animator>();
    }

    private void Update()
    {
        Vector3 direction = player.position - transform.position; //tranform is the enemy since our script is attached to enemy character
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg; ////Atan2- calculates the angle between enemy and player
        //rb.rotation = angle;
        direction.Normalize();
        movement = direction;
    }

    private void FixedUpdate()
    {
        MoveEnemy(movement);
        AnimateEnemy(movement);
    }


    void MoveEnemy(Vector2 direction)
    {
        rb.MovePosition((Vector2)transform.position + (direction * moveSpeed * Time.deltaTime));
        if (player.position.x > transform.position.x) //flip sprite
        {
            //player on right
            transform.localScale = new Vector3(1f, 1f, 1f);
        }
        else
        {
            //player on left
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }
    }

    void AnimateEnemy(Vector2 movement)
    {
        if (movement.x != 0)
        {
            anim.SetBool(walkAnimation, true);
        } else
        {
            anim.SetBool(walkAnimation, false);
        }
            
    }
    
}
