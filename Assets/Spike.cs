using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spike : MonoBehaviour
{
    public Transform defaultPoint;
    public Transform movePoint;
    public GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            transform.position = movePoint.position;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        transform.position = defaultPoint.position;
    }
}
