using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// muro que desaparece con placa de presión
public class secret_door : MonoBehaviour
{
    public int plates; // numero de placas
    MeshRenderer rend; // renderer del muro
    Collider m_Collider; // collider
    // Start is called before the first frame update
    void Start()
    {
        m_Collider = GetComponent<Collider>();
        rend = GetComponentInChildren<MeshRenderer>();
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
        rend.enabled = false;
        m_Collider.enabled = false;
    }
    // cerrar la puerta
    void close() {
        rend.enabled = true;
        m_Collider.enabled = true;
    }
}
