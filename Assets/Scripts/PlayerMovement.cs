using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Diagnostics;

public class PlayerMovement : MonoBehaviour
{
    // Chapter 1
    public bool holdingPaper = false;
    public bool holdingPlunger = false;

    // Chapter 2
    public bool holdingCart = false;
    public Sprite normalSprite;
    public Sprite holdingCartSprite;

    public Rigidbody2D playerRb;
    public float speed = 5f;
    public float input;
    public SpriteRenderer playerSprite;

    public bool isShifting = false;
    public bool isInTwoTriggers = false;
     
    public Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isShifting)
        {
            input = Input.GetAxisRaw("Horizontal");
        }

        if (input > 0)
        {
            playerSprite.flipX = false;
        }
        else if (input < 0)
        {
            playerSprite.flipX = true;
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            if (holdingCart)
            {
                PutDownCart();
            }
        }

        anim.SetFloat("Speed", Mathf.Abs(input));
    }

    void FixedUpdate()
    {
        playerRb.velocity = new Vector2(input * speed, playerRb.velocity.y);
    }

    public void PickUpCart()
    {
        holdingCart = true;

        // Temporary: Disable animation
        Destroy(anim);
        
        // Temporaty: Change sprite to holding cart
        playerSprite.sprite = holdingCartSprite;

        // Change posture to holding cart
        //anim.SetBool("HoldingCart", true);
    }

    public void PutDownCart()
    {
        holdingCart = false;

        playerSprite.sprite = normalSprite;
    }
}
