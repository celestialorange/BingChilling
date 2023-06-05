using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IceCreamCount : MonoBehaviour
{
    public List<GameObject> IceCreamFilledImages = new List<GameObject>();

    public GameManager gameManager;
    public GameObject Car2;
    public bool ShouldIceCreamCountEnabled;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        ShouldIceCreamCountEnabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(gameManager.isBulletIceCreamCreated)
        {
            gameObject.SetActive(true);
        }
        if(gameManager.IceCreamBulletCount >= 1)
        {
            IceCreamFilledImages[0].SetActive(true);
        }
        if(gameManager.IceCreamBulletCount >= 2)
        {
            IceCreamFilledImages[1].SetActive(true);
        }
        if(gameManager.IceCreamBulletCount >= 3)
        {
            IceCreamFilledImages[2].SetActive(true);
        }
        if(gameManager.IceCreamBulletCount <= 2)
        {
            IceCreamFilledImages[2].SetActive(false);
        }
        if(gameManager.IceCreamBulletCount <= 1)
        {
            IceCreamFilledImages[1].SetActive(false);
        }
        if(gameManager.IceCreamBulletCount <= 0)
        {
            IceCreamFilledImages[0].SetActive(false);
        }
    }
}
