using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IceCreamCount : MonoBehaviour
{
    public List<Image> IceCreamImages = new List<Image>();
    public GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(GameObject.Find("Car2") == null)
        {
            gameObject.SetActive(true);
        }
        if(gameManager.IceCreamBulletCount >= 1)
        {
            IceCreamImages[0].GetComponent<Image>().color = Color.white;
        }
        if(gameManager.IceCreamBulletCount >= 2)
        {
            IceCreamImages[1].GetComponent<Image>().color = Color.white;
        }
        if(gameManager.IceCreamBulletCount >= 3)
        {
            IceCreamImages[2].GetComponent<Image>().color = Color.white;
        }
        if(gameManager.IceCreamBulletCount <= 2)
        {
            IceCreamImages[2].GetComponent<Image>().color = Color.black;
        }
        if(gameManager.IceCreamBulletCount <= 1)
        {
            IceCreamImages[1].GetComponent<Image>().color = Color.black;
        }
        if(gameManager.IceCreamBulletCount <= 0)
        {
            IceCreamImages[0].GetComponent <Image>().color = Color.black;  
        }
    }
}
