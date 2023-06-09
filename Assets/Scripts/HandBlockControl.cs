using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandBlockControl : MonoBehaviour
{
    public IceCreamSpawn iceCreamSpawn;
    public Color defaultColor;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        defaultColor = gameObject.GetComponent<SpriteRenderer>().color;
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player") && player.transform.position.x > gameObject.transform.position.x)
        {
            gameObject.GetComponent<BoxCollider2D>().isTrigger = false;
            gameObject.GetComponent<SpriteRenderer>().color = new Color(defaultColor.r, defaultColor.g, defaultColor.b, 1.0f);
        }
    }
    void OnCollisionEnter2D(Collision2D collision2D)
    {
        if (transform.localScale.x > 0 && collision2D.gameObject.CompareTag("Player"))
        {
            collision2D.rigidbody.AddForce(new Vector2(5, 5));
        }
        else if (transform.localScale.x < 0 && collision2D.gameObject.CompareTag("Player"))
        {
            collision2D.rigidbody.AddForce(-new Vector2(5, 5));
        }
        else if (collision2D.gameObject.CompareTag("Car"))
        {
            iceCreamSpawn.ShouldSpawn = true;
        }
    }
}
