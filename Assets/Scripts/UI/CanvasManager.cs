using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CanvasManager : MonoBehaviour
{
	public GameObject HealthBar;
	public GameObject HealthBar2;
	public GameManager gameManager;
	public GameObject RestartButton;
	public GameObject TryAgainButton;
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
	public SoundFXManager soundFXManager;
	public JohnCenaControl johnCenaControl;
	

	public Image JohnCenaIceCream;
	public Transform JCICDefaultPos;
	public Transform JCICTargetPos;
	private float lerpTime;
	public float lerpSpeed;

	private bool ClearThemePlayed;

	// Start is called before the first frame update
	void Start()
	{
		HealthBar.SetActive(false);
		HealthBar2.SetActive(false);
		TrapBar.SetActive(false);
		RestartButton.SetActive(false);
		TryAgainButton.SetActive(false);
		BossHandHealth.SetActive(false);
		RestartButton.GetComponent<Button>().onClick.AddListener(OnRestartButtonClick);
		TryAgainButton.GetComponent<Button>().onClick.AddListener(OnRestartButtonClick);
		respawnManager = GameObject.Find("RespawnManager").GetComponent<RespawnManager>();
		playerControl = GameObject.FindGameObjectWithTag("Player").GetComponent<NewPlayerControl>();
	}

	// Update is called once per frame
	void Update()
	{
		if (gameManager.IceCreamEnabled)
		{
			HealthBar.SetActive(true);
			HealthBar2.SetActive(true);
		}
		//Dynamically Update the Health Amount.
		HealthBar.GetComponent<Image>().fillAmount = gameManager.IceCreamRemaining / gameManager.IceCreamMax;
		HealthBar2.GetComponent<Image>().fillAmount = (gameManager.IceCreamRemaining - gameManager.IceCreamMax) / gameManager.IceCreamMax;

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

		if (johnCenaControl.isGameTrulyCleared && !ClearThemePlayed)
		{
            soundFXManager.PlaySound(SoundType.WoyouBingchilling);
            lerpTime += lerpSpeed * Time.deltaTime;
			JohnCenaIceCream.rectTransform.position = Vector3.Lerp(JCICDefaultPos.position, JCICTargetPos.position, lerpTime);
			if(JohnCenaIceCream.rectTransform.position == JCICTargetPos.position)
			{
                soundFXManager.BGMSource.loop = false;
                soundFXManager.PlayBGM(BGMType.Clear);
				ClearThemePlayed = true;
				TryAgainButton.SetActive(true);
			}
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
