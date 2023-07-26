using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinController : MonoBehaviour
{

    [SerializeField]
    private GameObject coinPrefab;

    private GameObject coinClone;
    private int spawnIndex;

    [SerializeField]
    private Transform[] coinSpawnPoint;

    // Menyimpan collider bola
    public Collider bola;

    private int maxCoin = 3;
    public int coinCounter = 0;

    //Coin m_coin;

    private void Start()
    {
        StartCoroutine(AddCoin(1));
        //StartCoroutine(CoinTimerOff(10));
    }

   

    void spawnCoin()
    {
        spawnIndex = Random.Range(0, coinSpawnPoint.Length);
        coinClone = Instantiate(coinPrefab, coinSpawnPoint[spawnIndex].position, coinPrefab.transform.rotation);
    }




    public IEnumerator AddCoin(int times)
    {   
        StartCoroutine(CoinTimerOff(10));
        while (coinCounter < maxCoin)
        {
            yield return new WaitForSeconds(3);
            spawnCoin();
            Debug.Log("spawn" + coinCounter);
            coinCounter += 1;
        }
    }


    // Enum untuk mengatur state
    private IEnumerator CoinTimerOff(float time)
    {
        yield return new WaitForSeconds(10);
        Destroy(coinClone);
        coinCounter -= 1;
        Debug.Log("coin mati " + coinCounter);
        StartCoroutine(AddCoin(1));
        
    }

}
