using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaoGanMaTrophy : MonoBehaviour
{
    public GameManager GameManager;
    private Quaternion startRotation;
    private Quaternion endRotation;
    public float rSpeed;
    private float rTime = 0f;
    private int direction = 1;
    // Start is called before the first frame update
    void Start()
    {
        GameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        startRotation = Quaternion.Euler(0, 0, 30);
        endRotation = Quaternion.Euler(0, 0, -30);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        rTime += rSpeed * direction * Time.deltaTime;
        transform.rotation = Quaternion.Lerp(startRotation, endRotation, rTime);
        if(rTime >= 1f || rTime <= 0f)
        {
            direction *= -1;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) 
        {
            Destroy(gameObject);
            GameManager.IsPlayerGotLaoGanMa = true;
        }
    }
}
