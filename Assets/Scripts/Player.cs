using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField]
    public float moveForce = 10f;

    [SerializeField]
    public float jumpForce = 11f;

    public float movementX;

    public Rigidbody2D myBody;

    public SpriteRenderer sr;

    //private Animator anim;
    public string WALK_ANIMATION = "Walk";


    public void Awake()
    {

        myBody = GetComponent<Rigidbody2D>();
        //anim = GetComponent<Animator>();

        sr = GetComponent<SpriteRenderer>();

    }

    // Start is called before the first frame update
    public void Start()
    {
        
    }

    // Update is called once per frame
    public void Update()
    {
        PlayerMoveKeyboard();
        //AnimatePlayer();

    }
    /*
    private void FixedUpdate()
    {
        PlayerJump();
    }
*/
    public void PlayerMoveKeyboard() {

        movementX = Input.GetAxisRaw("Horizontal");

        transform.position += new Vector3(movementX, 0f, 0f) * moveForce * Time.deltaTime;

    }
    /*
    void AnimatePlayer() {

        // we are going to the right side
        if (movementX > 0)
        {
            anim.SetBool(WALK_ANIMATION, true);
            sr.flipX = false;
        }
        else if (movementX < 0)
        {
            // we are going to the left side
            anim.SetBool(WALK_ANIMATION, true);
            sr.flipX = true;
        }
        else
        {
            anim.SetBool(WALK_ANIMATION, false);
        }

    }

    void PlayerJump() {

        if (Input.GetButtonDown("Jump") && isGrounded) {
            isGrounded = false;
            myBody.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag(GROUND_TAG)) 
            isGrounded = true;
        

        if (collision.gameObject.CompareTag(ENEMY_TAG)) 
            Destroy(gameObject);
        

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(ENEMY_TAG))  
            Destroy(gameObject);   
    }
*/
} // class

