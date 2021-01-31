using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// puzzle de colores del tutorial
public class torches_4_door : MonoBehaviour
{
    // colores objetivo
    public ParticleSystem torch1;
    public ParticleSystem torch2;
    public ParticleSystem torch3;
    public ParticleSystem torch4;
    // antorchas/pilones a encenderm, cada uno debe de corresponder en color a los de arriba
    public ParticleSystem fire_holder1;
    public ParticleSystem fire_holder2;
    public ParticleSystem fire_holder3;
    public ParticleSystem fire_holder4;
    // scripts(delegados) de los pilones / antorchas
    public set_color holder1;
    public set_color holder2;
    public set_color holder3;
    public set_color holder4;
    // Start is called before the first frame update
    void Start()
    {
        // añadimos delegado para saber cada vez que se cambia un color
        holder1.on_change += check_code;
        holder2.on_change += check_code;
        holder3.on_change += check_code;
        holder4.on_change += check_code;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    // si todos los colores coinciden se abre la puerta
    void check_code() {
        if(torch1.startColor == fire_holder1.startColor && torch2.startColor == fire_holder2.startColor &&
            torch3.startColor == fire_holder3.startColor && torch4.startColor == fire_holder4.startColor) {
            
            Destroy(gameObject, 5);
            holder1.on_change -= check_code;
            holder2.on_change -= check_code;
            holder3.on_change -= check_code;
            holder4.on_change -= check_code;

        }

    }
}
