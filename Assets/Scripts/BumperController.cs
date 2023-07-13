using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BumperController : MonoBehaviour
{

    public Color color;
    private Renderer render;


    public float multiplier;
    public Collider bola;
    void Start()
    {
        render = GetComponent<Renderer>();
        render.material.color = color;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider == bola)
        {
            Rigidbody bolaRig = bola.GetComponent<Rigidbody>();

            bolaRig.velocity *= multiplier;
            Debug.Log("Kena Bola");
        }
    }
}
