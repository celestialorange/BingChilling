using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JohnCenaPopUp : MonoBehaviour
{
    public GameManager gameManager;
    /// <summary>
    /// The image will be moved
    /// </summary>
    public Image image;
    /// <summary>
    /// Defines the move speed of the Photo.
    /// </summary>
    [SerializeField] private float moveSpeed;
    /// <summary>
    /// Speed will be multiplied by this when moving back.
    /// </summary>
    [SerializeField] private float speedMultiplier;

    private bool isMoved;

    /// <summary>
    /// Times of image moves to screen area.
    /// </summary>
    [SerializeField] private int moveTime;
    /// <summary>
    /// Times of image waiting to move back.
    /// </summary>
    [SerializeField] private int waitTime;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        image = GetComponent<Image>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (GameObject.Find("Player") == null)
        {
            if (!isMoved)
            {
                image.transform.Translate(Vector2.up * moveSpeed * Time.deltaTime);
            }
            StartCoroutine(MovedToPosition());
        }
    }

    IEnumerator MovedToPosition()
    { 
        yield return new WaitForSeconds(moveTime);
        isMoved = true;
        StartCoroutine(ReturnToDefaultPosition());
    }
    IEnumerator ReturnToDefaultPosition()
    {
        yield return new WaitForSeconds(waitTime);
        while (isMoved)
        {
            yield return new WaitForSeconds(Time.deltaTime);
            image.rectTransform.Translate(Vector2.down * moveSpeed * speedMultiplier * Time.deltaTime);
        }
        yield return new WaitForSeconds(2.0f);
        Destroy(this.gameObject);
    }  
}
