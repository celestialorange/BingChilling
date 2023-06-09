using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Level2Intro : MonoBehaviour
{
    public CinemachineVirtualCamera playerCamera;
    public GameObject FollowObject;
    public RespawnManager respawnManager;
    public GameObject player;

    public FollowUp followUp;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && player.transform.position.x > gameObject.transform.position.x)
        {
            followUp.isYaxisShouldMove = true;
            playerCamera.Follow = FollowObject.transform;
            respawnManager.PlayerTouchedRespawnPoint(gameObject.transform);
            gameObject.GetComponent<Collider2D>().isTrigger = false;
            //followUp.currentPosition.position = player.transform.position;
        }
    }
}
