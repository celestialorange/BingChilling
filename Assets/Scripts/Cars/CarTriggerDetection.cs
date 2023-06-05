using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarTriggerDetection : MonoBehaviour
{
    public CarMove carMove;
    // Start is called before the first frame update
    void Start()
    {
        carMove = gameObject.GetComponentInChildren<CarMove>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            carMove.ShouldCarMove = true;
        }
    }
}
