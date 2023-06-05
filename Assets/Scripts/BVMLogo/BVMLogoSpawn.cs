using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BVMLogoSpawn : MonoBehaviour
{
    public GameObject BVMLogo;
    public Transform SpawnPoint;
    private bool ShouldSpawn;

    // Start is called before the first frame update
    void Start()
    {
        SpawnPoint = transform.GetChild(0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            ShouldSpawn = true;
            StartCoroutine(SpawnLogo(0.5f));
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            ShouldSpawn = false;
        }
    }

    IEnumerator SpawnLogo(float spawnTime)
    {
        while (ShouldSpawn)
        {
            yield return new WaitForSeconds(spawnTime);
            Instantiate(BVMLogo, new Vector3(Random.Range(-2 + SpawnPoint.transform.position.x, 2 + SpawnPoint.transform.position.x), SpawnPoint.transform.position.y, 0), Quaternion.Euler(0, 0, 4 * Time.deltaTime));
        }
    }
}
