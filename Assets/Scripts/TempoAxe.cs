using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TempoAxe : MonoBehaviour
{

    public GameManager gameManager;// Start is called before the first frame update
    void Start()
    {
        gameManager= GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            gameManager.ShouldLaoGanMaDestroyed = true;
        }
    }
}
