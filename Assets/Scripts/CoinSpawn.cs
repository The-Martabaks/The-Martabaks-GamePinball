using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawn : MonoBehaviour
{

    public GameObject coinOri;

    private GameObject clonCoin;

    public Collider bola;

    private int spawnIndex;

    [SerializeField]
    private Transform[] coinSpawnPoint;

    private static List<object> coinSpawn = new List<object>();
    // Start is called before the first frame update
    void Start()
    {
        creatCoin(3);
    }

    void creatCoin(int coinsNum)
    {
        spawnIndex = Random.Range(0, coinSpawnPoint.Length); 
        clonCoin = Instantiate(coinOri, coinSpawnPoint[spawnIndex].position, coinOri.transform.rotation);
        coinSpawn.Add(clonCoin);
        Debug.Log(coinSpawn.Count);
        
    }

    private void OnTriggerEnter(Collider other)
    {
        // Memastikan yang menabrak adalah bola
        if (other == bola)
        {
            Destroy(clonCoin);
        }
    }

    // void OnCollisionEnter(Collision collision)
    // {
    //     Rigidbody bolaRig = bola.GetComponent<Rigidbody>();
        
    // }
    

}
