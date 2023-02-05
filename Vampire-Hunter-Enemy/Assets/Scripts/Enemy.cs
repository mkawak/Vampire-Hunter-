using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Transform player;
    public float moveSpeed = 1f;
    private Rigidbody2D rb;
    private Vector2 movement;


    private void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Vector3 direction = player.position - transform.position; //tranform is the enemy since our script is attached to enemy character
        //Atan2- calculates the angle between enemy and player
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg; //angle in degrees
        rb.rotation = angle;
        direction.Normalize();
        movement = direction;
        //Debug.Log(direction);
    }
    private void FixedUpdate()
    {
        MoveCharacter(movement);
    }
    void MoveCharacter(Vector2 direction)
    {
        rb.MovePosition((Vector2)transform.position + (direction * moveSpeed * Time.deltaTime));
    }
    
}
