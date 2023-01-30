using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 10f;
    
    void Move(float horiz, float vert, float deltaTime) {
	transform.position += new Vector3(horiz * moveSpeed * deltaTime, vert * moveSpeed * deltaTime, 0);
    } 

    // Update is called once per frame
    void Update()
    {
        float horiz = Input.GetAxis("Horizontal");
        float vert = Input.GetAxis("Vertical");

        Move(horiz, vert, Time.deltaTime);
    }
}
