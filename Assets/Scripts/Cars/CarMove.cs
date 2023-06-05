using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CarMove : MonoBehaviour
{
    public bool ShouldCarMove;
    private Rigidbody2D rb2d;
    [SerializeField] private float speed;
    public NewPlayerControl playerControl;
    [SerializeField] private float lateMoveTime;
    public bool carDirection;
    public GameManager gameManager;
    /// <summary>
    /// Recommended to set from 0 to 1.
    /// </summary>
    [SerializeField] private float carSpeedRatio;
    public CinemachineVirtualCamera playerCamera;
    public IceCreamCount iceCreamCount;
    public IceCreamSpawn iceCreamSpawn;
    // Start is called before the first frame update
    void Start()
    {
        rb2d = gameObject.GetComponent<Rigidbody2D>();
        playerControl = GameObject.Find("Player").GetComponent<NewPlayerControl>();
        playerCamera = GameObject.FindGameObjectWithTag("PlayerCamera").GetComponent<CinemachineVirtualCamera>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (ShouldCarMove)
        {
            if (carDirection)
            {
                //rb2d.velocity = Vector2.right * speed * Time.deltaTime;
                StartCoroutine(LateMove());
            }
            else rb2d.velocity = Vector2.left * speed * Time.deltaTime;

            //transform.Translate(Vector2.left * speed * Time.deltaTime, Space.World);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        string switchLayerName = "NoCollision";
        int switchLayer = LayerMask.NameToLayer(switchLayerName);
        float carSpeed = gameObject.GetComponent<Rigidbody2D>().velocity.magnitude;
        float knockbackDistance = carSpeed * carSpeedRatio;
        Vector2 knockbackForce = new Vector2(-knockbackDistance, 3f);
        Vector3 PositionOnCollision = transform.position;
        if (collision.rigidbody.gameObject.CompareTag("Player"))
        {
            GameObject player = collision.rigidbody.gameObject;
            Vector3 currentPosition = player.transform.position;
            if (switchLayer != -1)
            {
                player.layer = switchLayer;
                playerControl.isPlayerTrapped = true;
                player.transform.position = new Vector3(currentPosition.x, currentPosition.y, 0.05f);
                player.GetComponent<Rigidbody2D>().AddForce(knockbackForce, ForceMode2D.Impulse);
                player.GetComponent<Rigidbody2D>().freezeRotation = false;
                player.transform.rotation = Quaternion.Euler(0, 0, 30f);
                playerCamera.Follow = null;
                ShouldCarMove = false;
                StartCoroutine(DestroyPlayer());
            }
            else
            {
                Debug.LogError("Failed to switch player's layer to " + switchLayerName);
            }
        }
        else if (collision.rigidbody.gameObject.CompareTag("Hand"))
        {
            gameManager.isBulletIceCreamCreated = true;
            iceCreamSpawn.ShouldSpawn = true;
            //StartCoroutine(iceCreamSpawn.SpawnIceCream(0.1f));
            iceCreamSpawn.IceCreamSpawnNow();
            Destroy(gameObject);
        }
        
        IEnumerator DestroyPlayer()
        {
            yield return new WaitForSeconds(2.0f);
            //Destroy(GameObject.Find("Player"));
            GameObject.Find("Player").SetActive(false);
            gameManager.IsPlayerDead = true;
            
        }
        
    }

 IEnumerator LateMove()
    {
        yield return new WaitForSeconds(lateMoveTime);
        while (ShouldCarMove)
        {
            yield return new WaitForSeconds(Time.deltaTime);
            rb2d.velocity = Vector2.right * speed * Time.deltaTime;
        }
       
    }
}
