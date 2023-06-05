using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spike : MonoBehaviour
{
    public Transform defaultPoint;
    public Transform movePoint;
    public GameManager gameManager;
    public NewPlayerControl playerControl;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        playerControl = GameObject.FindWithTag("Player").GetComponent<NewPlayerControl>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playerControl.isPlayerTrapped = true;
            playerControl.gameObject.transform.position = this.gameObject.transform.position;
            other.attachedRigidbody.velocity = Vector2.zero;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        transform.position = defaultPoint.position;
    }

}
