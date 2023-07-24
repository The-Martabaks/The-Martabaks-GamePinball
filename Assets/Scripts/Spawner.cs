using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    private Transform bolaPos;
    private Transform spawnPoint;

    public Collider bola;

    void Start()
    {
        bolaPos = GameObject.FindGameObjectWithTag("Player").transform;
        spawnPoint = GameObject.FindGameObjectWithTag("Respawn").transform;
    }

    private void OnCollisionEnter(Collision collision)
    {
        Rigidbody bolaRig = bola.GetComponent<Rigidbody>();
        bolaPos.position = new Vector3(spawnPoint.position.x, spawnPoint.position.y, spawnPoint.position.z);
    }
}
