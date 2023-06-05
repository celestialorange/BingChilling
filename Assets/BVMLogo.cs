using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BVMLogo : MonoBehaviour
{
    public GameManager gameManager;
    public float IceCreamMeltAmount;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        StartCoroutine(DestroySelf(1f));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator DestroySelf(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        Destroy(gameObject);
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collision happened with: " + collision.gameObject.name.ToString()); 
        if (collision.gameObject.CompareTag("Player"))
        {
            gameManager.IceCreamRemaining -= IceCreamMeltAmount;
        }
    }
}
