using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RestartButton : MonoBehaviour
{
    public RespawnManager respawnManager;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<Button>().onClick.AddListener(OnButtonClicked);
        respawnManager = GameObject.Find("RespawnManager").GetComponent<RespawnManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnButtonClicked()
    {
        if (player.activeSelf)
        {
            //Destroy(GameObject.Find("Player"));
            player.SetActive(false);
            respawnManager.RespawnPlayer();
        }
        else if (!player.activeSelf)
        {
            respawnManager.RespawnPlayer();
        }
        
    }
}
