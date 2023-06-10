using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerControl : MonoBehaviour
{
    private Rigidbody2D rb;
    private Collider2D col2d;
    private Animator anim;

    public float speed, jumpForce;
    public Transform groundCheck;
    public LayerMask ground;

    public bool isGround, isJump;
    public bool isPlayerTrapped;

    bool jumpPressed;
    int jumpCount;

    public GameManager gameManager;

    //Fire Ice Cream Bullets
    public bool CouldFireIceCreamBullets;
    public Transform FirePos;
    public GameObject IceCreamBullet;

    public SoundFXManager soundFXManager;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        col2d = GetComponent<Collider2D>();
        anim = GetComponent<Animator>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        isPlayerTrapped = false;
    }

    void Update()
    {
        if (Input.GetButtonDown("Jump") && jumpCount > 0)
        {
            jumpPressed = true;
        }
        if(Input.GetButtonDown("Fire1") && gameManager.IceCreamBulletCount >= 1 && CouldFireIceCreamBullets)
        {
            Fire();
        }
        if (gameManager.isBulletIceCreamCreated)
        {
            CouldFireIceCreamBullets = true;
        }

    }

    void FixedUpdate()
    {
        isGround = Physics2D.OverlapCircle(groundCheck.position, 0.1f, ground);
        if (!isPlayerTrapped)
        {
            GroundMovement();
            Jump();
        }
        
    }

    void GroundMovement()
    {
        float horizontalMove = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(horizontalMove * speed, rb.velocity.y);

        if(horizontalMove != 0)
        {
            transform.localScale = new Vector3(horizontalMove, 1, 1);
        }
    }

    void Jump()
    {
        if (isGround)
        {
            jumpCount = 2;
            isJump = false;
        }
        if(jumpPressed && isGround)
        {
            isJump = true;
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            jumpCount--;
            jumpPressed = false;
        }
        else if (jumpPressed && jumpCount > 0 && !isGround)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            jumpCount--;
            jumpPressed = false;
        }

        /*else if (jumpPressed && !isGround){
         * 
         * }*/
        void SwitchAnim()
        {

        }

       
    }
    void Fire()
    {
        Instantiate(IceCreamBullet, FirePos.position, Quaternion.identity);
        gameManager.IceCreamBulletCount -= 1;
    }

}


    
 

