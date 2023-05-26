using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiantLaoGanMa : MonoBehaviour
{
    public GameManager gameManager;
    public GameObject laoGanMa;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.ShouldLaoGanMaDestroyed)
        {
            Destroy(gameObject);
            laoGanMa.SetActive(true);
        }
    }

   

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.otherCollider.gameObject.CompareTag("Player"))
        {
            gameManager.IceCreamMeltSpeed *= 2;
            Invoke("ReturnNormalSpeed", 3);
        }
    }
    void ReturnNormalSpeed()
    {
        gameManager.IceCreamMeltSpeed /= 2;
    }
}
