using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public Collider bola;
  
    void Update()
    {
        transform.Rotate(new Vector3(0f, 0f, 150f) * Time.deltaTime);
    }
    void OnCollisionEnter(Collision collision)
    {
        Rigidbody bolaRig = bola.GetComponent<Rigidbody>();
        Destroy(gameObject);
        
        
        
    }

}
