using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateRespawnPoints : MonoBehaviour
{
    public RespawnManager respawnManager;
    
    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<UnityEngine.UI.Button>().onClick.AddListener(OnClick);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnClick()
    {
        respawnManager.isRespawnPointActivated = true;
    }
}
