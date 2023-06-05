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
    }
    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector2(player.localScale.x * speed * Time.deltaTime, player.position.y));
        transform.rotation = Quaternion.Euler(0, 0, speed * Time.deltaTime);
        StartCoroutine(DestroySelf(5f));
    }

    IEnumerator DestroySelf(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Hand"))
        {
            bossHand.health -= 3;
            Destroy(gameObject);
        }
    }
}
