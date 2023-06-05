using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OMove : MonoBehaviour
{
    public GameManager gameManager;
    public Vector3 startPosition;
    public Transform EndPosition;
    public float moveSpeed;
    private float t = 0f;
    public bool ShouldOMove;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        startPosition = transform.position;
        ShouldOMove = false;
    }

    // Update is called once per frame
    void Update()
    {
        t += moveSpeed * Time.deltaTime;
        if (gameManager.IsPlayerDead && ShouldOMove)
        {
            transform.position = Vector3.Lerp(startPosition, EndPosition.position, t);
            if(transform.position == EndPosition.position)
            {
                ShouldOMove = false;
            }
        }
        else if (!gameManager.IsPlayerDead)
        {
            transform.position = startPosition;
        }
    }
    public IEnumerator MakeOMove(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        //while (gameManager.IsPlayerDead)
        //{
        //    yield return null;
        //    transform.position = Vector3.Lerp(startPosition, EndPosition.position, moveSpeed);
        //}
        transform.position = Vector3.Lerp(startPosition, EndPosition.position, t);
    }
}
