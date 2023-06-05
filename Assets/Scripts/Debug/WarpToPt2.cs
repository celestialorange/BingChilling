using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarpToPt2 : MonoBehaviour
{
    public Transform player;
    public Transform part2Gate;
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
        player.position = part2Gate.position + new Vector3(-3, 2);
    }
}
