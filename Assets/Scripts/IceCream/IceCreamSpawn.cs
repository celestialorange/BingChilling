using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceCreamSpawn : MonoBehaviour
{
    public GameManager gameManager;
    public GameObject IceCreamCollective;
    public Transform SpawnPoint;
    public bool ShouldSpawn;
    //private bool SpawnCoroutineCreated;

    // Start is called before the first frame update
    void Start()
    {
        SpawnPoint = transform.GetChild(0);
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        //SpawnCoroutineCreated = false;
    }

    // Update is called once per frame
    void Update()
    {
        //if (gameManager.isBulletIceCreamCreated)
        //{
        //    StartCoroutine(SpawnIceCream(0.1f));
        //    ShouldSpawn = true;
        //}
    }


   IEnumerator SpawnIceCream()
    {
        while (ShouldSpawn)
        {
            yield return new WaitForSeconds(0.2f);
            Instantiate(IceCreamCollective, new Vector3(Random.Range(-6 + SpawnPoint.transform.position.x, 6 + SpawnPoint.transform.position.x), SpawnPoint.transform.position.y, 0), Quaternion.identity);
            if (gameManager.IsPlayerDead)
            {
                yield break;
            }
            else if (GameObject.Find("BossHand") == null)
            {
                yield break;
            }
        }
    }

    //void OnTriggerStay2D(Collider2D collision)
    //{
    //    if (gameManager.isBulletIceCreamCreated && !SpawnCoroutineCreated)
    //    {
    //       StartCoroutine(SpawnIceCream(0.1f));
    //       ShouldSpawn = true;
    //       SpawnCoroutineCreated = true;
    //    }
    //}

    public void IceCreamSpawnNow()
    {
       
           StartCoroutine(SpawnIceCream());
           ShouldSpawn = true;
            //SpawnCoroutineCreated = true;
        
    }
}
