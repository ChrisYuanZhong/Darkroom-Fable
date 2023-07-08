using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Diagnostics;

public class PlayerMovement : MonoBehaviour
{
    public bool holdingPaper = false;
    public bool holdingPlunger = false;

    public Rigidbody2D playerRb;
    public float speed = 5f;
    public float input;
    public SpriteRenderer playerSprite;

    public bool isShifting = false;
    public bool isInTwoTriggers = false;
     
    Animator anim;

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

        anim.SetFloat("Speed", Mathf.Abs(input));
    }

    void FixedUpdate()
    {
        playerRb.velocity = new Vector2(input * speed, playerRb.velocity.y);
    }
}
