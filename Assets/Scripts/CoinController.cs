using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinController : MonoBehaviour
{
    [SerializeField]
    private GameObject coinPrefab;

    private GameObject coinTemp;
    private int spawnIndex;

    [SerializeField]
    private GameObject[] coinSpawnPoint;

    // Menyimpan collider bola
    public List<Collider> coin = new List<Collider>();

    private int maxCoin = 3;
    private int coinCounter = 0;

    private void Start()
    {
        StartCoroutine(AddCoin(1));
    }

    private void Update()
    {
        OnCollisionEnter(coin);
    }

    void spawnCoin()
    {
        spawnIndex = Random.Range(0, coinSpawnPoint.Length);
        if (coinSpawnPoint[spawnIndex].activeSelf == false)
        {
            coinSpawnPoint[spawnIndex].SetActive(true);
            coinCounter += 1;
        }
        else
        {
            while (coinSpawnPoint[spawnIndex].activeSelf == true)
            {
                spawnIndex = Random.Range(0, coinSpawnPoint.Length);
            }
            coinSpawnPoint[spawnIndex].SetActive(true);
            coinCounter += 1;
        }
    }

    private void OnCollisionEnter(Collider other)
    {
        // Memastikan yang menabrak adalah bola
        if (other.gameObject.tag == "coin")
        {
            other.gameObject.SetActive(false);
        }
    }

    private IEnumerator AddCoin(int times)
    {
        for(int i=0; i<maxCoin; i++)
        {
            yield return new WaitForSeconds(3);
            spawnCoin();
            Debug.Log("spawn" + coinCounter);
        }
        StartCoroutine(CoinTimerOff(10));
    }

    // Enum untuk mendestroy koin
    private IEnumerator CoinTimerOff(float time)
    {
        yield return new WaitForSeconds(time);
        //this.coinSpawnPoint[].SetActive(false);
        coinCounter -= 1;
        Debug.Log("coin mati");
    }
}
