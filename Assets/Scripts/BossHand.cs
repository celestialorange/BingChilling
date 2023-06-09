using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHand : MonoBehaviour
{
    public float health;
    public float defaultHealth;
    public bool isInvincible;
    public float damageAmount;
    public float currentHealth;
    private Transform localPosition;
    private bool isMoved;
    public Transform targetPosition;
    public Transform originPosition;
    public float moveSpeed;
    public float rotateSpeed;
    private float rotateTime = 0f;

    private float attackTimer;
    public float attackWaitTime;
    private bool shouldTimerStart;
    // Start is called before the first frame update
    void Start()
    {
        attackTimer = attackWaitTime;
        shouldTimerStart = false;
        defaultHealth = 60;
        health = defaultHealth;
        isInvincible = true;
        localPosition = gameObject.GetComponent<Transform>();
        //targetPosition = new Vector3(localPosition.position.x - 10, localPosition.position.y);
    }

    // Update is called once per frame
    void Update()
    {
        if (shouldTimerStart)
        {
            attackTimer -= Time.deltaTime;
            if (attackTimer <= 0)
            {
                StartCoroutine(Move());
                attackTimer = attackWaitTime;
            }
        }
       
        if(health <= 0)
        {
            Destroy(gameObject);
        }
        currentHealth = health;
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name == "Car2")
        {
            isInvincible = false;
            shouldTimerStart = true;
        }
        if (collision.gameObject.CompareTag("Bullet"))
        {
            health -= damageAmount;
        }        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    { 
        if (collision.gameObject.CompareTag("Bullet"))
        {
            health -= damageAmount;
        }
    }

  IEnumerator Move()
    {
        while (!isInvincible && !isMoved)
        {
            //yield return new WaitForSeconds(0.1f);
            yield return new WaitForSeconds(0.02f);
            //transform.position = Vector3.Lerp(localPosition.position, targetPosition.position, 0.5f);
            transform.Translate(Vector3.left * moveSpeed * Time.deltaTime, Space.World);
            rotateTime += rotateSpeed * Time.deltaTime;
            transform.rotation = Quaternion.Lerp(Quaternion.identity, Quaternion.Euler(0, 0, 90), rotateTime);
            if (Mathf.Abs(targetPosition.position.x - transform.position.x) <= 0.1f)
            {
                isMoved = true;
                Debug.Log("1" );
                break;

            }
        }
       
        while (!isInvincible && isMoved)
        {
            //yield return new WaitForSeconds(0.1f);
            yield return new WaitForSeconds(0.02f);
            //transform.position = Vector3.Lerp(originPosition.position, localPosition.position, 0.5f);
            transform.Translate(Vector3.right * moveSpeed * 2 * Time.deltaTime, Space.World);
            rotateTime -= rotateSpeed * Time.deltaTime;
            transform.rotation = Quaternion.Lerp(Quaternion.Euler(0, 0, 90), Quaternion.identity, rotateTime);
            if (Mathf.Abs(originPosition.position.x - transform.position.x) <= 0.1f)
            {
                isMoved = false;
                Debug.Log("2" );

            }
        }
    
        
    }

}
