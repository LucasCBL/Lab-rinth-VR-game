using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// puzle de la sala final
public class final_puzzle : MonoBehaviour
{
    // colores oobjetivo
    public ParticleSystem torch1;
    public ParticleSystem torch2;
    public ParticleSystem torch3;
    // antorchas/pilones a encenderm, cada uno debe de corresponder en color a los de arriba
    public ParticleSystem fire_holder1;
    public ParticleSystem fire_holder2;
    public ParticleSystem fire_holder3;
    // scripts(delegados) de los pilones / antorchas
    public set_color holder1;
    public set_color holder2;
    public set_color holder3;
    // Start is called before the first frame update
    void Start()
    {
        // añadimos delegado para saber cada vez que se cambia un color
        holder1.on_change += check_code;
        holder2.on_change += check_code;
        holder3.on_change += check_code;

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void check_code() {
        // si todos los colores coinciden se abre la puerta
        if(torch1.startColor == fire_holder1.startColor && torch2.startColor == fire_holder2.startColor &&
            torch3.startColor == fire_holder3.startColor ) {
            
            Destroy(gameObject, 5);
            holder1.on_change -= check_code;
            holder2.on_change -= check_code;
            holder3.on_change -= check_code;


        }

    }
}
