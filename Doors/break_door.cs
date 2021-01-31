using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// script para muros rompibles
public class break_door : MonoBehaviour
{
    public Animator anim;
    private int break_d = Animator.StringToHash("break");
    private AudioSource breaking_sound; // sonido puerta
    // Start is called before the first frame update
    void Start()
    {
        // buscamos el audio source del componente
        breaking_sound = gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void play_break() {
        breaking_sound.Play();
        anim.SetTrigger(break_d); // activamos la animación hecha en blender
        Destroy(gameObject, 8f); // destruimos el objeto a los 8 segundos de ser este atacado
    }
}
