using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHand : MonoBehaviour
{
    public int health;
    public int defaultHealth;
    public bool isInvincible;
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
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name == "Car2")
        {
            isInvincible = false;
        }
        if (collision.gameObject.CompareTag("Bullet") && !isInvincible)
        {
            health -= 5;
        }
    }
}
