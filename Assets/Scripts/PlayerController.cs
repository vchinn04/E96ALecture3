using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    // Component references
    // TODO: create variable to store rigidbody of player (2D)
    // TODO: create variable storing the Animator
    Rigidbody2D rb; 

    [SerializeField] float speed = 5f;
    [SerializeField] float jumpHeight = 5f;
    float direction = 0f;
    bool isFacingRight = true; 
    //TODO: keep track of current horizontal movement direction


    //keep track of if the player is on the ground
    bool isGrounded = false;

    //TODO: keep track of which direction player is facing


    // Start is called before the first frame update
    void Start()
    {
        rb = transform.GetComponent<Rigidbody2D>();
        // TODO: Get references to the rigidbody and animator attached to the current GameObject

    }

    // Update is called once per frame
    void Update()
    {
        // TODO: Pass in the proper direction that the player should move in
        Move(direction);

        // TODO: check conditions needed to flip player, and if so, flip player

    }

    void OnJump()
    {
        //if player is on the ground, jump
        //if (isGrounded)
        Jump();
    }

    private void Jump()
    {
        // TODO: change y velocity of player
        rb.velocity = new Vector2(rb.velocity.x, jumpHeight);


    }

    public void OnMove(InputValue moveVal)
    {
        // TODO: store direction input and store it to global variable
        float movDirection = moveVal.Get<float>();
        direction = movDirection;

    }

    private void Move(float x)
    {
        // TODO: change x velocity of player
        rb.velocity = new Vector2(direction * speed, rb.velocity.y);
        // TODO: Here, we can handle animation transitioning logic
        if ((isFacingRight && direction == -1f) || (!isFacingRight && direction == 1f))
            Flip();
    }

    private void Flip()
    {
        isFacingRight = !isFacingRight;
        // TODO: flip local scale of player and change global variable that stores which direction player is facing
        Vector3 newLocalScale = transform.localScale;
        newLocalScale.x *= -1f;
        transform.localScale = newLocalScale;

    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Collectibles"))
            {
            Destroy(col.gameObject);
        }
    }
    // TODO: Week 3's assignment needs a couple of extra functions here...
}
