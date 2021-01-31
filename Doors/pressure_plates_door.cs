using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// puerta abierta con placas de presion
public class pressure_plates_door : MonoBehaviour
{
    public int plates; // numero de placas de presión inicial
    ParticleSystem system; // sistema de particulas de la puerta
    Collider m_Collider; // collider de la puerta
    // Start is called before the first frame update
    void Start()
    {
        m_Collider = GetComponent<Collider>();
        system = GetComponentInChildren<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    // se activa una placa
    public void add_plate() {
        plates--;
        if(plates == 0) {
            open();
        } 
    }
    // se desactiva una placa
    public void subtract_plate() {
        plates++;
        if(plates > 0) {
            close();
        } 
    }

    // abrir la pueerta
    void open() {
        system.Stop();
        m_Collider.enabled = false;
    }
    // cerrar la puerta
    void close() {
        system.Play();
        m_Collider.enabled = true;
    }
}
