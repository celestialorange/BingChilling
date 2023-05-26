using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandBlockControl : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            gameObject.GetComponent<BoxCollider2D>().isTrigger = false;
        }
        else if (other.CompareTag("Car"))
        {
            Destroy(other.gameObject);
        }
    }
    void OnCollisionEnter2D(Collision2D collision2D)
    {
        if (transform.localScale.x > 0)
        {
            collision2D.otherRigidbody.AddForce(new Vector2(5, 5));
        }
        else if (transform.localScale.x < 0)
        {
            collision2D.otherRigidbody.AddForce(-new Vector2(5, 5));
        }
    }
}
