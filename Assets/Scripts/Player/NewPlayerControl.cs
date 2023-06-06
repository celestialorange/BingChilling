using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class NewPlayerControl : MonoBehaviour
{

    //Trap Detection
    public bool isPlayerTrapped;
    //Fall Detection
    public GameObject fallAnchor;

    //Motion Controls
    public float speed = 5f;
    public float jumpForce = 5f;
    public int maxJumpCount = 2;

    private Rigidbody2D rb;
   [SerializeField]   private bool isJumping;
    public int jumpCount;

    //Animations
    public Animator animator;

    //Game Manager
    public GameManager gameManager;

    //Fire Ice Cream Bullets
    public bool CouldFireIceCreamBullets;
    public Transform FirePos;
    public GameObject IceCreamBullet;
    //public IceCreamBullet iceCreamBullet;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        jumpCount = maxJumpCount;
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        FirePos = transform.GetChild(1);
    }

    void Update()
    {
        if (!isPlayerTrapped)
        {
            MovePlayer();
        }
        if (Input.GetButtonDown("Fire1") && gameManager.IceCreamBulletCount >= 1 && CouldFireIceCreamBullets)
        {
            Fire();
        }

        if (gameManager.isBulletIceCreamCreated)
        {
            CouldFireIceCreamBullets = true;
        }
    }



    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.contacts[0].normal.y > 0.7f)
        {
            isJumping = false;
            jumpCount = maxJumpCount;
        }

    }

    void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        isJumping = true;
        animator.SetBool("IsPlayerJump", true);
    }

    void MovePlayer()
    {
        //Jump Controls
        float moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);
        Debug.Log(rb.velocity);

        if (Input.GetButtonDown("Jump"))
        {
            if (isJumping)
            {
                if (jumpCount > 0)
                {
                    Jump();
                    jumpCount--;
                }
            }
            else
            {
                Jump();
                jumpCount--;
            }
        }

        //Fall Detection
        if (gameObject.transform.position.y <= fallAnchor.transform.position.y)
        {
            gameObject.SetActive(false);
            gameManager.IsPlayerDead = true;
        }

        //Animation Control
        if (Input.GetButton("Horizontal"))
        {
            animator.SetBool("IsPlayerRun", true);
            if (rb.velocity.x < 0)
            {
                transform.localScale = new Vector3(-1, 1, 0);

            }
            if (rb.velocity.x > 0)
            {
                transform.localScale = new Vector3(1, 1, 0);
            }
            if (rb.velocity.y > 0.01f)
            {
                animator.SetBool("IsPlayerRun", false);
                animator.SetBool("IsPlayerJump", true);
                animator.SetBool("IsPlayerJumpDown", false);
            }
            else if (rb.velocity.y < -0.01f)
            {
                animator.SetBool("IsPlayerRun", false);
                animator.SetBool("IsPlayerJump", false);
                animator.SetBool("IsPlayerJumpDown", true);
            }
            else
            {
                animator.SetBool("IsPlayerJump", false);
                animator.SetBool("IsPlayerJumpDown", false);
                animator.SetBool("IsPlayerRun", true);
            }
        }
        else
        {
            animator.SetBool("IsPlayerRun", false);
            animator.SetBool("IsPlayerJump", false);
            animator.SetBool("IsPlayerJumpDown", false);
        }

    }
    void Fire()
    {
        Instantiate(IceCreamBullet, FirePos.position, Quaternion.identity);
        gameManager.IceCreamBulletCount -= 1;
    }
}
