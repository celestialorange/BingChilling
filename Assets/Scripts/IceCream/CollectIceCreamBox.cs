using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectIceCreamBox : MonoBehaviour
{
    public GameManager gameManager;
    public float MeltRecoverAmount;
    
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(gameObject);
            gameManager.IceCreamRemaining += MeltRecoverAmount;
        }
    }
}
