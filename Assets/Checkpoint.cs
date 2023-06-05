using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public Sprite CheckpointUntriggered;
    public Sprite CheckpointTriggered;
    public bool isTriggered;
    public RespawnManager respawnManager;
    // Start is called before the first frame update
    void Start()
    {
        isTriggered = false;
        respawnManager = GameObject.Find("RespawnManager").GetComponent<RespawnManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isTriggered)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = CheckpointTriggered;
        }
        else gameObject.GetComponent<SpriteRenderer>().sprite = CheckpointUntriggered;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") && !isTriggered)
        {
            isTriggered = true;
            respawnManager.PlayerTouchedRespawnPoint(this.gameObject.transform);
        }
    }
}
