using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject player;
    /// <summary>
    /// 冰淇淋剩余时间
    /// </summary>
    public float IceCreamRemaining;
    public float IceCreamMax;
    public float IceCreamMeltSpeed;

    public bool IceCreamEnabled;
    public bool IsPlayerDead;
    public bool IsPlayerGotLaoGanMa;
    public NewPlayerControl playerControl;
    public bool ShouldLaoGanMaDestroyed;
    /// <summary>
    /// 调节陷阱相关
    /// </summary>
    public float FreeFromTrapMaxAmount;
    public float FreeFromTrapSpeed;
    public float FreeFromTrapCurrentAmount;
    public int IceCreamBulletCount;

    public SoundFXManager soundFXManager;

    //存档点相关
    public List<Checkpoint> Checkpoints;
    public int CheckpointStatus;

    public bool isBulletIceCreamCreated;
    // Start is called before the first frame update
    void Awake()
    {
        PlayerPrefs.SetInt("IceCreamCollected", 0);
        IceCreamEnabled = false;
        IsPlayerDead = false;
        IsPlayerGotLaoGanMa = false;
        ShouldLaoGanMaDestroyed = false;
        IceCreamBulletCount = 0;
        isBulletIceCreamCreated = false;
}

    void Start()
    {
        IceCreamMax = 100.0f;
        IceCreamRemaining = 80.0f;
       playerControl = GameObject.Find("Player").GetComponent<NewPlayerControl>();
        FreeFromTrapCurrentAmount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //Ice cream related mechanics.
        if (IceCreamEnabled)
        {
            IceCreamRemaining -= IceCreamMeltSpeed * Time.deltaTime;
        }

        if(IceCreamBulletCount >= 3)
        {
            IceCreamBulletCount = 3;
        }

        if (IceCreamRemaining <= 0 && !IsPlayerDead)
        {
            CommonDead();
        }
        if (IsPlayerGotLaoGanMa )
        {
            playerControl.speedScale = 1.5f;
        }
        if (playerControl.isPlayerTrapped && Input.GetButtonDown("Horizontal"))
        {
            FreeFromTrapCurrentAmount += FreeFromTrapSpeed;
            if(FreeFromTrapCurrentAmount >= FreeFromTrapMaxAmount)
            {
                playerControl.isPlayerTrapped = false;
                FreeFromTrapCurrentAmount = 0;
                playerControl.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(Random.Range(-2,2),6);
            }
        }
        
    }

   public IEnumerator IE_PlayerCrashed(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        CommonDead();
    }

    public void PlayerCrash(float waitTime)
    {
        StartCoroutine(IE_PlayerCrashed(waitTime));
    }

    public void CommonDead()
    {
        if (!IsPlayerDead)
        {
            player.SetActive(false);
            IsPlayerDead = true;
            soundFXManager.PlaySound(SoundType.KO);
            soundFXManager.BGMSource.Stop();
            soundFXManager.BGMSource.loop = false;
            Invoke("PlayKOBgm", soundFXManager.KOSound.length);
        }
    }

    void PlayKOBgm()
    {
        soundFXManager.PlayBGM(BGMType.KO);
    }

    //void CheckpointDefenition()
    //{
    //    if (Checkpoints[0].isTriggered)
    //    {
    //        if (Checkpoints[1].isTriggered)
    //        {
    //            CheckpointStatus = 2;
    //        }
            
    //    }
       
    //}
    
}