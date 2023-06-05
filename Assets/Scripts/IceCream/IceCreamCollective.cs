using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceCreamCollective : MonoBehaviour
{
    public GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        Invoke("DestroySelf", 6f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Destroy(gameObject);
            gameManager.IceCreamBulletCount += 1;
        }
    }

    void DestroySelf()
    {
        Destroy(gameObject);
    }
}
