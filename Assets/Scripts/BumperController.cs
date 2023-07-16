using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BumperController : MonoBehaviour
{

    public Color color;
    private Renderer render;

    private Animator animator;


    public float multiplier;
    public Collider bola;
    void Start()
    {
        render = GetComponent<Renderer>();
        render.material.color = color;

        animator = GetComponent<Animator>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider == bola)
        {
            Rigidbody bolaRig = bola.GetComponent<Rigidbody>();

            animator.SetTrigger("Hit");

            bolaRig.velocity *= multiplier;
            Debug.Log("Kena Bola");
        }
    }
}
