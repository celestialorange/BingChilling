using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UIElements;

public class JohnCenaControl : MonoBehaviour
{
    public GameManager GameManager;
    public Sprite newSprite;
    public SoundFXManager soundFXManager;
    public bool isGameCleared;
    public bool isGameTrulyCleared;
    public NewPlayerControl playerControl;
    // Start is called before the first frame update
    void Start()
    {
        GameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

        isGameCleared = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
   private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if(isGameCleared)
            {
                SpriteRenderer spriteRenderer = gameObject.GetComponent<SpriteRenderer>(); 
                spriteRenderer.sprite = newSprite;
                soundFXManager.PlaySound(SoundType.JCThemeSound);
                Invoke("GameTrulyCleared", soundFXManager.JCThemeSound.length);
                playerControl.isGameCleared = true;
                playerControl.gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
                playerControl.gameObject.transform.position = gameObject.transform.position;
            }
        }
    }

    void GameTrulyCleared()
    {
        isGameTrulyCleared = true;
    }
}
