using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class PlayerControl : MonoBehaviour
{

    public Animator animator;
    //HorizontalMoveControl
      public float speed;
      public Rigidbody2D rb;
      public float xVelocity;

    public void GroundMovement()
    {
        xVelocity = Input.GetAxisRaw("Horizontal"); //ʹ��GetAxisRawʵ�־�ȷ���ƣ�GetAxis����ֽ�ɫ�޷�����ֹͣ������
        rb.velocity = new Vector2(xVelocity * speed, rb.velocity.y);
        if (Input.GetButtonDown("Horizontal"))
        {
            if (xVelocity < 0)
            {
                transform.localScale = new Vector3(-1, 1, 0);
                
            }
            if (xVelocity > 0)
            {
                transform.localScale = new Vector3(1, 1, 0);
            }
        }
        if (Input.GetButton("Horizontal") && !Input.GetButton("Jump"))
        {
            animator.SetBool("IsPlayerRun", true);
        }
        else animator.SetBool("IsPlayerRun", false);
    }
            //JumpControl
            public float jumpForce;
            public float fallMultiplier;
            public float lowJumpMultiplier;
            public bool pressJump;
            public int jumpNum;
            public int jumpRemainNum;
    public bool isOnGround;
    public float groundDistance = 0.2f;
    public float footOffset = 0.4f;
    public float rayPozitionY = -0.5f;
    public LayerMask groundLayer;

   //�Խ�ɫ�������ƶ����������ж�
    RaycastHit2D Raycast(Vector2 offset, Vector2 rayDirection, float length, LayerMask layer)
    {
        Vector2 pos = transform.position;
        RaycastHit2D hit = Physics2D.Raycast(pos + offset, rayDirection, length, layer);
        Color color = hit ? Color.red : Color.green;
        Debug.DrawRay(pos + offset, rayDirection * length, color);
        return hit;
    }

    void PhysicsCheck()
    {
        RaycastHit2D leftCheck = Raycast(new Vector2(-footOffset, rayPozitionY), Vector2.down, groundDistance, groundLayer);
        RaycastHit2D rightCheck = Raycast(new Vector2(footOffset, rayPozitionY), Vector2.down, groundDistance, groundLayer);
        if(leftCheck || rightCheck)
        {
            isOnGround = true;
        }
        else isOnGround = false;
    }

    void Jump()
    {
        if (Input.GetButtonDown("Jump")) 
        {
            if (isOnGround)
            {
                jumpRemainNum = jumpNum;
            }
            if (pressJump && jumpRemainNum-- > 0)
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            }
        }
        if(rb.velocity.y < 0)
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * fallMultiplier * Time.deltaTime;
            animator.SetBool("IsPlayerJump", true);
        }
        else if (rb.velocity.y > 0 && !pressJump) 
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * lowJumpMultiplier * Time.deltaTime;
            animator.SetBool("IsPlayerJump", false);
            animator.SetBool("IsPlayerJumpDown", true);
        }
        else if(rb.velocity.y == 0 && !pressJump)
        {
            animator.SetBool("IsPlayerJump", false);
            animator.SetBool("IsPlayerJumpDown", false);
        }
    }


    //Main Event
    void Start()
        {
            rb = gameObject.GetComponent<Rigidbody2D>();
            animator = gameObject.GetComponent<Animator>();
        }

        // Update is called once per frame
        void Update()
        {
        pressJump = Input.GetButton("Jump");
        Jump();
    }

        void FixedUpdate()
        {
        PhysicsCheck();
        GroundMovement();
        
        /*Vector2 velocity = rb.velocity;
        velocity.x = speed;
        rb.velocity = velocity;*/
    }

    }

