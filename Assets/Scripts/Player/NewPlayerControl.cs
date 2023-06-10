using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class NewPlayerControl : MonoBehaviour
{

    //Trap Detection
    public bool isPlayerTrapped;
    public bool isCarCrash;
    public bool isGameCleared;
    //Fall Detection
    public GameObject fallAnchor;

    //Motion Controls
    //public bool isPlayerMove;
    public float speed = 5f;
    public float speedScale = 1f;
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

    public SoundFXManager soundFXManager;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        jumpCount = maxJumpCount;
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        FirePos = transform.GetChild(1);
        isPlayerTrapped = false;
        isCarCrash = false;
        isGameCleared = false;
    }

    void Update()
    {
        if (!isPlayerTrapped && !isCarCrash && !isGameCleared)
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
        rb.velocity = new Vector2(moveInput * speed * speedScale, rb.velocity.y);
        //Debug.Log(rb.velocity);

        if (Input.GetButtonDown("Jump"))
        {
            if (isJumping)
            {
                if (jumpCount > 0)
                {
                    Jump();
                    jumpCount--;
                    soundFXManager.PlaySound(SoundType.Jump);
                }
            }
            else
            {
                Jump();
                jumpCount--;
                soundFXManager.PlaySound(SoundType.Jump);
            }
        }

        //Fall Detection
        if (gameObject.transform.position.y <= fallAnchor.transform.position.y)
        {
            gameManager.CommonDead();
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
        Instantiate(IceCreamBullet, FirePos.position, Quaternion.Euler(0,0, transform.localScale.x * 90));
        gameManager.IceCreamBulletCount -= 1;
        soundFXManager.PlaySound(SoundType.IceCreamFire);
    }
}
