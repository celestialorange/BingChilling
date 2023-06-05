using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikePopUp : MonoBehaviour
{
    public float speed;
    public float popTime;
    public bool isPlayerInSpikeArea;
    private bool ShouldMove;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.gameObject.CompareTag("Player"))
        {
            isPlayerInSpikeArea = true;
            ShouldMove = true;
            StartCoroutine(SpikeMove());
            Invoke("StopMove", popTime);
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        { 
            isPlayerInSpikeArea = false;
            ShouldMove = true;
            StartCoroutine(SpikeMove());
            Invoke("StopMove", popTime);
        }
    }

    void StopMove()
    {
        StopCoroutine(SpikeMove());
        ShouldMove = false;
    }

    IEnumerator SpikeMove()
    {
        while (isPlayerInSpikeArea && ShouldMove)
        {
            yield return new WaitForSeconds(Time.deltaTime);
            transform.Translate(Vector2.up * speed * Time.deltaTime);
        }
        while (!isPlayerInSpikeArea && ShouldMove)
        {
            yield return new WaitForSeconds(Time.deltaTime);
            transform.Translate(Vector2.down * speed * Time.deltaTime);
        }
        yield return null;
    }
}
