using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// cambiar el color de la luz del jugador
public class pick_color : MonoBehaviour
{
    public ParticleSystem fire; // particulas
    private AudioSource light_up_sound; // sonido
    // Start is called before the first frame update
    void Start()
    {
        light_up_sound = gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public Color get_color() {
        light_up_sound.Play();
        return fire.startColor; // el jugador usa el color de las partículas
    }
}
