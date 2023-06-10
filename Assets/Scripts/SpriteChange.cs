using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteChange : MonoBehaviour
{
    public TextChangeManager textChangeManager;
    public Sprite BingChilingText;
    public SoundFXManager soundFXManager;
    // Start is called before the first frame update
    void Start()
    {
        int RandomIndex = Random.Range(0, 3);
        GetComponent<SpriteRenderer>().sprite = textChangeManager.ChineseTexts[RandomIndex];
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player") && other.transform.position.y > gameObject.transform.position.y)
        {
           GetComponent<SpriteRenderer>().sprite = BingChilingText;
            soundFXManager.PlaySound(SoundType.Bingchilling);
        }
    }
}
