using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 10f;
    Animator animator;

    public bool moving = false;

    public void Start() {
        animator = GetComponent<Animator>();
        gameObject.tag = "Player";
    }

    public float GetSpeed() {return moveSpeed;}
    public void SetSpeed(float newSpeed) {moveSpeed = newSpeed;}
    
    public void Move(float horiz, float vert, float deltaTime) {
	    transform.position += new Vector3(horiz * moveSpeed * deltaTime, vert * moveSpeed * deltaTime, 0);
    } 

    // Update is called once per frame
    public void Update()
    {
        moveSpeed = GetComponent<PlayerCharacter>().baseSpeed;

        float horiz = Input.GetAxis("Horizontal");
        float vert = Input.GetAxis("Vertical");

        if (horiz != 0 || vert != 0) moving = true;
        else moving = false;

        if (horiz < 0) transform.eulerAngles = new Vector3(0, 180, 0);
        else if (horiz > 0) transform.eulerAngles = new Vector3(0, 0, 0);

        animator.SetBool("isMoving", moving);

        Move(horiz, vert, Time.deltaTime);
    }
}
