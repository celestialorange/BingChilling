using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetIceCream : MonoBehaviour
{
    public GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        gameObject.GetComponent<UnityEngine.UI.Button>().onClick.AddListener(OnClick);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnClick()
    {
        gameManager.IceCreamRemaining = gameManager.IceCreamMax;
    }
}
