using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KMove : MonoBehaviour
{
    public GameManager gameManager;
    public Transform EndPosition;
    public Vector3 startPosition;
    public float moveSpeed;
    private float t = 0f;
    public OMove oMove;
    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.IsPlayerDead)
        {
            t += moveSpeed * Time.deltaTime;
            transform.position = Vector3.Lerp(startPosition, EndPosition.position, t);
            //StartCoroutine(oMove.MakeOMove(0.2f));
            StartCoroutine(CallO());
        }
        else transform.position = startPosition;

    }
    IEnumerator CallO()
    {
        yield return new WaitForSeconds(0.2f);
        oMove.ShouldOMove = true;
    }
}
