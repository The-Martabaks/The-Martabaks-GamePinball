using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BumperController : MonoBehaviour
{
    public Color bumperColor;
    private Renderer bumperRenderer;
    public int hitCounter;
    private Animator animator;


    public float multiplier;
    public Collider bola;

    void Start()
    {
        hitCounter = 0;
        bumperRenderer = GetComponent<Renderer>();
        bumperColor = bumperRenderer.material.color;
        bumperRenderer.material.color = new Color(255, 0, 0);

        animator = GetComponent<Animator>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider == bola)
        {
            Rigidbody bolaRig = bola.GetComponent<Rigidbody>();
            bumperRenderer.material.color = new Color(0, 255, 0);
            if(hitCounter == 0)
            {
                bumperRenderer.material.color = new Color(0, 255, 0);
                hitCounter = 1;
            }
            else if (hitCounter == 1)
            {
                bumperRenderer.material.color = new Color(255, 255, 0);
                hitCounter = 2;
            }
            else if (hitCounter == 2)
            {
                bumperRenderer.material.color = new Color(255, 0, 0);
                hitCounter = 0;
            }
            //animator.SetTrigger("Hit");

            bolaRig.velocity *= multiplier;
            Debug.Log("Kena Bola");

        }
    }
}
