using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Starting game");
    }

    // Update is called once per frame
    // one frame per second
    void Update()
    {
        float h = Input.GetAxis("Horizontal"); // gets input from the A/D key
        float v = Input.GetAxis("Vertical"); // gets input from the W/S key

        Vector2 pos = transform.position; // assuming this is a 2D vector, therefor has x and y axes
                                          //gets the current position of the object in the scene
        pos.x += h * speed * Time.deltaTime;
        pos.y += v * speed * Time.deltaTime;

        transform.position = pos;
    }
}
