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
    // Start is called before the first frame update
    void Start()
    {
        HealthBar.SetActive(false);
        RestartButton.SetActive(false);
        RestartButton.GetComponent<Button>().onClick.AddListener(OnRestartButtonClick);
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
    }

    void OnRestartButtonClick()
    {
        SceneManager.LoadScene(thisLevel);
        PlayerPrefs.SetInt("IceCreamCollected", 0);
    }
}
