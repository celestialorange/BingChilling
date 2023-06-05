using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Level3Intro : MonoBehaviour
{
    public CinemachineVirtualCamera playerCamera;
    public GameObject player;
    public RespawnManager respawnManager;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == player)
        {
            playerCamera.Follow = player.transform;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        gameObject.GetComponent<Collider2D>().isTrigger = false;
        respawnManager.PlayerTouchedRespawnPoint(gameObject.transform);
    }
}