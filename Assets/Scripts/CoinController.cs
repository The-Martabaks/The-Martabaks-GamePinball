using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinController : MonoBehaviour
{
    private enum SwitchState
    {
        Off,
        On,
        Add
    }

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


    private void OnTriggerEnter(Collider other)
    {
        // Memastikan yang menabrak adalah bola
        if (other == bola)
        {
            Destroy(coinClone);
            // Toggle();
        }
    }

    // Fungsi untuk toggle
    // private void Toggle()
    // {
    //     if (state == SwitchState.On || state == SwitchState.Add)
    //     {
    //         Set(false);
            
    //     }
    // }

    // private void Set(bool active)
    // {
    //     if (active == true)
    //     {
    //         state = SwitchState.On;

    //         StartCoroutine(AddCoin(1));
    //     }
    //     else
    //     {
    //         state = SwitchState.Off;
    //         Destroy(coinClone);
    //     }
    // }

    private IEnumerator AddCoin(int times)
    {
        //state = SwitchState.Add;
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
