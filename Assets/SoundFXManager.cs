using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    // Update is called once per frame
    void Update()
    {
        if (gameManager.IsPlayerDead)
        {
            FXSource.clip = KOSound;
            FXSource.Play();
        }
    }
}

