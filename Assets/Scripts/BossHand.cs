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
   
    // Start is called before the first frame update
    void Start()
    {
        defaultHealth = 60;
        health = defaultHealth;
        isInvincible = true;
    }

    // Update is called once per frame
    void Update()
    {
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

}
