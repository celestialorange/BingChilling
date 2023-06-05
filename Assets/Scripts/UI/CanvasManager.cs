using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CanvasManager : MonoBehaviour
{
	public GameObject HealthBar;
	public GameManager gameManager;
	public GameObject RestartButton;
	public string thisLevel;
	public List<Checkpoint> checkpoints;
	public RespawnManager respawnManager;
	public GameObject TrapBar;
	public NewPlayerControl playerControl;
	public GameObject BossHandHealth;
	public BossHand bossHand;
   
	//public IceCreamSpawn iceCreamSpawn;
	public IceCreamCount iceCreamCount;
	public GameObject iceCreamCountMeter;

	// Start is called before the first frame update
	void Start()
	{
		HealthBar.SetActive(false);
		TrapBar.SetActive(false);
		RestartButton.SetActive(false);
		BossHandHealth.SetActive(false);
		RestartButton.GetComponent<Button>().onClick.AddListener(OnRestartButtonClick);
		respawnManager = GameObject.Find("RespawnManager").GetComponent<RespawnManager>();
		playerControl = GameObject.FindGameObjectWithTag("Player").GetComponent<NewPlayerControl>();
	}

	// Update is called once per frame
	void Update()
	{
		if (gameManager.IceCreamEnabled)
		{
			HealthBar.SetActive(true);
		}
		//Dynamically Update the Health Amount.
		HealthBar.GetComponent<Image>().fillAmount = gameManager.IceCreamRemaining / gameManager.IceCreamMax;

		if(gameManager.IsPlayerDead)
		{
			RestartButton.SetActive(true);
		}
		else if (!gameManager.IsPlayerDead)
		{
			RestartButton.SetActive(false);
		}

		if (playerControl.isPlayerTrapped)
		{
			TrapBar.gameObject.SetActive(true);
			//TrapBar.GetComponent<Image>().fillAmount = gameManager.FreeFromTrapCurrentAmount / gameManager.FreeFromTrapMaxAmount;
		}
		else if (!playerControl.isPlayerTrapped)
		{
			TrapBar.gameObject.SetActive(false);
		}

		if (gameManager.isBulletIceCreamCreated)
		{
			BossHandHealth.SetActive(true);
			iceCreamCount.ShouldIceCreamCountEnabled = true;
			iceCreamCountMeter.SetActive(true);
			//BossHandHealth.GetComponent<Image>().fillAmount = (bossHand.health / bossHand.defaultHealth);
		}
		BossHandHealth.GetComponent<Image>().fillAmount = bossHand.currentHealth / bossHand.defaultHealth;
        TrapBar.GetComponent<Image>().fillAmount = gameManager.FreeFromTrapCurrentAmount / gameManager.FreeFromTrapMaxAmount;
    }

	void OnRestartButtonClick()
	{
		respawnManager.RespawnPlayer();
		//SceneManager.LoadScene(thisLevel);
		//PlayerPrefs.SetInt("IceCreamCollected", 0);
	}
}
