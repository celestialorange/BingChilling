using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Cinemachine;

public class RespawnManager : MonoBehaviour
{
    public List<Transform> respawnPoints;
    public GameObject player;
    public GameManager gameManager;
    public BossHand bossHand;
    public CinemachineVirtualCamera playerCamera;
    [SerializeField] private string SpawnLevel;
    public FollowUp followUp;
    public bool isRespawnPointActivated;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayerTouchedRespawnPoint(Transform respawnPoint)
    {
        if (!respawnPoints.Contains(respawnPoint))
        {
            respawnPoints.Add(respawnPoint);
        }
    }

    // 此方法用于在玩家死亡时复活在最后一个接触的复活点
    public void RespawnPlayer()
    {
        if (respawnPoints.Count > 0 && isRespawnPointActivated)
        {
            Transform lastRespawnPoint = respawnPoints[respawnPoints.Count - 1];
            if(lastRespawnPoint == null)
            {
                Debug.LogError("Failed to initialize Respawn Point.");
            }
            player.transform.position = lastRespawnPoint.position + Vector3.up * 2 + Vector3.right * 2;
            player.transform.rotation = Quaternion.identity;
            //Instantiate(player, lastRespawnPoint.transform.position + Vector3.up * 2, Quaternion.identity);
            player.layer = 3;
            gameManager.IceCreamRemaining = 80;
            gameManager.IceCreamBulletCount = 3;
            if (bossHand.health <= 30)
            {
                bossHand.health *= 2;
            }
            else bossHand.health = 60;
            player.GetComponent<NewPlayerControl>().isPlayerTrapped = false;

            if (player.activeSelf == false)
            {
                player.SetActive(true);
            }


            
            playerCamera.LookAt = player.transform;
            followUp.currentPosition.position = player.transform.position;

        }
        else
        {
            // 如果没有接触过任何复活点，则执行默认的复活逻辑
            SceneManager.LoadScene(SpawnLevel);
            PlayerPrefs.SetInt("IceCreamCollected", 0);
        }
    }
}
