using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowUp : MonoBehaviour
{
    public bool isYaxisShouldMove;
    public GameObject player;
    public float moveSpeed;
    public Transform currentPosition;
    public GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        currentPosition = gameObject.transform;
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if (!isYaxisShouldMove)
        {
            currentPosition.position = player.transform.position;
            gameObject.transform.position = player.transform.position;
        }
        if (isYaxisShouldMove)
        {
            gameObject.transform.position = new Vector3(player.transform.position.x, currentPosition.position.y + moveSpeed * Time.deltaTime);
        }

        if(player.transform.position.y < gameObject.transform.position.y - 13)
        {
            gameManager.CommonDead();
        }

        if (gameManager.IsPlayerDead)
        {
            moveSpeed = 0;
        }
    }
}


