using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public float IceCreamRemaining;
    public float IceCreamMax;
    public float IceCreamMeltSpeed;
    public bool IceCreamEnabled;
    public bool IsPlayerDead;
    public bool IsPlayerGotLaoGanMa;
    public NewPlayerControl playerControl;
    public bool ShouldLaoGanMaDestroyed;

    public int IceCreamBulletCount;
    // Start is called before the first frame update
    void Awake()
    {
        PlayerPrefs.SetInt("IceCreamCollected", 0);
        IceCreamEnabled = false;
        IsPlayerDead = false;
        IsPlayerGotLaoGanMa = false;
        ShouldLaoGanMaDestroyed = false;
        IceCreamBulletCount = 0;
}

    void Start()
    {
        IceCreamMax = 100.0f;
        IceCreamRemaining = 80.0f;
       playerControl = GameObject.Find("Player").GetComponent<NewPlayerControl>();
    }

    // Update is called once per frame
    void Update()
    {
        //Ice cream related mechanics.
        if (IceCreamEnabled)
        {
            IceCreamRemaining -= IceCreamMeltSpeed * Time.deltaTime;
        }

        if (IceCreamRemaining <= 0)
        {
            Destroy(GameObject.Find("Player"));
            IsPlayerDead = true;
        }
        if (IsPlayerGotLaoGanMa)
        {
            playerControl.speed *= 2;
        }
    }
}