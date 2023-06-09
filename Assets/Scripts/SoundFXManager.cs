using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SoundType
{
    KO
}

public class SoundFXManager : MonoBehaviour
{
    public GameManager gameManager;
    public AudioClip KOSound;
    public AudioSource FXSource;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    public void PlaySound(SoundType soundType)
    {
        switch (soundType)
        {
            case SoundType.KO:
                FXSource.clip = KOSound;
                break;
        }
        FXSource.time = 0;
        FXSource.Play();
        Debug.Log("playsound+ " + soundType);
    }
}

