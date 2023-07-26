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

    // Menggantikan isOn
    //private SwitchState state;
    private int maxCoin = 3;
    private int coinCounter = 0;

    private void Start()
    {
        //Set(true);
        StartCoroutine(AddCoin(1));
        //StartCoroutine(CoinTimerOff(10));
    }
    

    void spawnCoin()
    {
        spawnIndex = Random.Range(0, coinSpawnPoint.Length);
        coinClone = Instantiate(coinPrefab, coinSpawnPoint[spawnIndex].position, coinPrefab.transform.rotation);
    }

    // void OnCollisionEnter(Collision collision)
    // {
    //     Rigidbody bolaRig = bola.GetComponent<Rigidbody>();
    //     Debug.Log("Kena Koin");
    //     Destroy(coinClone);
        
    // }

    // private void OnTriggerEnter(Collider other)
    // {
    //     // Memastikan yang menabrak adalah bola
    //     if (other == bola)
    //     {
    //         Destroy(coinClone);
    //         // Toggle();
    //     }
    // }


    private IEnumerator AddCoin(int times)
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
