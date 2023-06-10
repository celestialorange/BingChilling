using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SoundType
{
    KO,
    JCThemeSound,
    CarCrash,
    Hit,
    Jump,
    IceCreamCollected,
    IceCreamFire,
    IceCreamBoxCollected,
    LargeIceCreamBoxCollected,
    Jackpot,
    Bingchilling,
    WoyouBingchilling
}

public enum BGMType
{
    Normal,
    Battle,
    Clear,
    KO
}

public class SoundFXManager : MonoBehaviour
{
    public GameManager gameManager;
    [Header("Sound")]
    public AudioClip KOSound;
    public AudioClip JCThemeSound;
    public AudioClip CarCrashSound;
    public AudioClip HitSound;
    public AudioClip JumpSound;
    public AudioClip IceCreamCollected;
    public AudioClip IceCreamBoxCollected;
    public AudioClip IceCreamFire;
    public AudioClip Jackpot;
    public AudioClip LargeIceCreamBoxCollected;
    public AudioClip BingChilling;
    public AudioClip WoYouBingChilling;
    [Header("BGM")]
    public AudioClip NormalBgm;
    public AudioClip BattleBgm;
    public AudioClip ClearBgm;
    public AudioClip KOBgm;
    [Header("Sources")]
    public AudioSource FXSource;
    public AudioSource BGMSource;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        BGMSource.loop = true;
    }

    public void PlaySound(SoundType soundType)
    {
        switch (soundType)
        {
            case SoundType.KO:
                FXSource.clip = KOSound;
                break;
            case SoundType.JCThemeSound:
                FXSource.clip = JCThemeSound;
                break;
            case SoundType.CarCrash:
                FXSource.clip = CarCrashSound;
                break;
            case SoundType.Hit:
                FXSource.clip = HitSound;
                break;
            case SoundType.Jump:
                FXSource.clip = JumpSound;
                break;
            case SoundType.IceCreamFire:
                FXSource.clip = IceCreamFire;
                break;
            case SoundType.IceCreamCollected:
                FXSource.clip = IceCreamCollected;
                break;
            case SoundType.IceCreamBoxCollected:
                FXSource.clip= IceCreamBoxCollected;
                break;
            case SoundType.Jackpot:
                FXSource.clip = Jackpot;
                break;
            case SoundType.LargeIceCreamBoxCollected:
                FXSource.clip = LargeIceCreamBoxCollected;
                break;
            case SoundType.Bingchilling:
                FXSource.clip = BingChilling;
                break;
            case SoundType.WoyouBingchilling:
                FXSource.clip = WoYouBingChilling;
                break;
        }
        FXSource.time = 0;
        FXSource.Play();
        Debug.Log("playsound+ " + soundType);
    }

    public void PlayBGM(BGMType type)
    {
        switch (type)
        {
            case BGMType.Normal:
                BGMSource.clip = NormalBgm;
                break;
            case BGMType.Battle:
                BGMSource.clip = BattleBgm;
                break;
            case BGMType.Clear:
                BGMSource.clip = ClearBgm;
                break;
            case BGMType.KO:
                BGMSource.clip=KOBgm;
                break;
        }
        BGMSource.time = 0;
        BGMSource.Play();
    }
    
}    

