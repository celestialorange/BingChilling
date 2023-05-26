using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaoGanMaTrophy : MonoBehaviour
{
    public GameManager GameManager;
    // Start is called before the first frame update
    void Start()
    {
        GameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
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
            GameManager.IsPlayerGotLaoGanMa = true;
        }
    }
}
