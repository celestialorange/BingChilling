using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceCreamBullet : MonoBehaviour
{
    public Transform player;
    public float speed;
    public BossHand bossHand;
    // Start is called before the first frame update
    void Start()
    {
        bossHand = GameObject.Find("BossHand").GetComponent<BossHand>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        Invoke("DestroySelf", 5f);
    }
    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(player.localScale.x * speed * Time.deltaTime, 0), Space.World);
        transform.rotation = Quaternion.Euler(0, 0, speed * Time.deltaTime);
        
    }

    void DestroySelf()
    {
        Destroy(gameObject);
    }

    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if (collision.gameObject.CompareTag("Hand"))
    //    {
    //        bossHand.health -= bossHand.damageAmount;
    //       Destroy(gameObject);
    //    }
    // }

    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (collision.gameObject.CompareTag("Hand"))
    //    {
    //        bossHand.health -= bossHand.damageAmount;
    //        Destroy(gameObject);
    //    }
    //}
}
