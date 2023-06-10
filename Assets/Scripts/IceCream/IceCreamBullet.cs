using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceCreamBullet : MonoBehaviour
{
    public float direction;
    public float speed;
    //public BossHand bossHand;

    private bool isInit = false;
    // Start is called before the first frame update
    void Start()
    {
        //bossHand = GameObject.Find("BossHand").GetComponent<BossHand>();
        direction = GameObject.FindGameObjectWithTag("Player").transform.localScale.x;
        Invoke("DestroySelf", 5f);

        isInit = true;
    }
    // Update is called once per frame
    void Update()
    {
        if (!isInit)
        {
            return;
        }
        transform.Translate(new Vector3(direction * speed * Time.deltaTime, 0), Space.World);
        //transform.rotation = Quaternion.Euler(0, 0, speed * Time.deltaTime);
        
    }

    void DestroySelf()
    {
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
       if (collision.gameObject.CompareTag("Hand"))
        {
          //bossHand.health -= bossHand.damageAmount;
          Destroy(gameObject);
       }
     }

    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (collision.gameObject.CompareTag("Hand"))
    //    {
    //        bossHand.health -= bossHand.damageAmount;
    //        Destroy(gameObject);
    //    }
    //}
}
