using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IceCreamUISpin : MonoBehaviour
{
    public Image HealthBar;
    public Image HealthBar2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = Quaternion.Euler(0, 0, -HealthBar2.fillAmount * 360);
        if (HealthBar2.fillAmount <=0)
        { 
            transform.rotation = Quaternion.Euler(0, 0, -HealthBar.fillAmount * 360);
        }
    }
}
