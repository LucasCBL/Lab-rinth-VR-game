using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// objeto con partículas al que se puede cambiar el color y encender
public class set_color : MonoBehaviour
{
    public ParticleSystem fire; // partículas
    private AudioSource light_up_sound;
    public delegate void changed_color();
    public event changed_color on_change; // evento
    // Start is called before the first frame update
    void Start()
    {
        light_up_sound = gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    // cambio de color
    public void set_fire_color(Color hue) {
        fire.startColor = hue;
        light_up_sound.Play();
        fire.Play();
        on_change();
    }
}
