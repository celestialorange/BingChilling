using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShaderKeywordFilter;
using UnityEngine;

public class CollectIceCream : MonoBehaviour
{
    private GameManager gameManager;
    private Vector2 DefaultPosition;
    public SoundFXManager soundFXManager;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        DefaultPosition = gameManager.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
       // this.transform.position = Vector3.Lerp(new Vector3(DefaultPosition.x, DefaultPosition.y - 1, 0), new Vector3(DefaultPosition.x, DefaultPosition.y + 1, 0), 1 * Time.deltaTime);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            gameManager.IceCreamEnabled = true;
            Destroy(this.gameObject);
            
        }   
    }
    private void OnDestroy()
    {
        soundFXManager.PlaySound(SoundType.IceCreamCollected);
    }
}
