using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectIceCreamBox : MonoBehaviour
{
    public GameManager gameManager;
    public float MeltRecoverAmount;
    public SoundFXManager soundFXManager;
    
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(gameObject);
            gameManager.IceCreamRemaining += MeltRecoverAmount;
        }
    }
    private void OnDestroy()
    {
        if (gameObject.CompareTag("LargeIceCreamBox"))
        {
            soundFXManager.PlaySound(SoundType.LargeIceCreamBoxCollected);
        }
        else soundFXManager.PlaySound(SoundType.IceCreamBoxCollected);
    }
}
