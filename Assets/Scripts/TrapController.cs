using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapController : MonoBehaviour
{
       [SerializeField]
    private GameObject trapPrefab;

    private GameObject trapClone;
    private int spawnIndex;

    [SerializeField]
    private Transform[] trapSpawnPoint;

    // Menyimpan collider bola
    public Collider bola;

    private int maxTrap = 3;
    public int trapCounter = 0;

    //Coin m_coin;

    private void Start()
    {
        StartCoroutine(AddTrap(1));
        //StartCoroutine(CoinTimerOff(10));
    }

   

    void spawnTrap()
    {
        spawnIndex = Random.Range(0, trapSpawnPoint.Length);
        trapClone = Instantiate(trapPrefab, trapSpawnPoint[spawnIndex].position, trapPrefab.transform.rotation);
    }




    public IEnumerator AddTrap(int times)
    {   
        StartCoroutine(TrapTimerOff(10));
        while (trapCounter < maxTrap)
        {
            yield return new WaitForSeconds(3);
            spawnTrap();
            Debug.Log("spawn" + trapCounter);
            trapCounter += 1;
        }
    }


    // Enum untuk mengatur state
    private IEnumerator TrapTimerOff(float time)
    {
        yield return new WaitForSeconds(10);
        Destroy(trapClone);
        trapCounter -= 1;
        Debug.Log("Trap mati " + trapCounter);
        StartCoroutine(AddTrap(1));
        
    }

}
