using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchController : MonoBehaviour
{
    private enum SwitchState
    {
        Off,
        On,
        Blink
    }

    // Menyimpan collider bola
    public Collider bola;

    // Menimpan variabel material nyala dan mati untuk merubah warna
    public Material offMaterial;
    public Material onMaterial;

    // Menggantikan isOn
    private SwitchState state;

    // Komponen renderer pada object yang akan di ubah
    private Renderer render;

    private void Start()
    {
        // Ambil renderer
        render = GetComponent<Renderer>();

        Set(false);
        
        StartCoroutine(BlinkTimerStart(5));
    }
    

    private void OnTriggerEnter(Collider other)
    {
        // Memastikan yang menabrak adalah bola
        if(other == bola)
        {
		    Toggle();
        }
    }

    // Fungsi untuk toggle
    private void Toggle()
    {
        // dari on --> off
        if(state == SwitchState.On)
        {
            Set(false);
        }
        else // dari off --> on atau blink --> on
        {
            Set(true);
        }
    }

    private void Set(bool active)
    {
        
        if(active == true)
        {
            state = SwitchState.On;
            render.material = onMaterial;

            // Menghentikan blink
            StopAllCoroutines();
        }
        else
        {
            state = SwitchState.Off;
            render.material = offMaterial;
        }
    }

    private IEnumerator Blink(int times)
    {

        state = SwitchState.Blink;

        // Ulangan perubahan nyala dan mati sebanyak parameter

        for(int i = 0; i < times; i++)
        {
            render.material = onMaterial;
            yield return new WaitForSeconds(0.5f);
            render.material = offMaterial;
            yield return new WaitForSeconds(0.5f);
        }

        state = SwitchState.Off;
        StartCoroutine(BlinkTimerStart(5));
        
        
    }


    // Enum untuk mengatur state
    

    private IEnumerator BlinkTimerStart(float time)
    {
        yield return new WaitForSeconds(time);
        StartCoroutine(Blink(2));
    }


    
}
