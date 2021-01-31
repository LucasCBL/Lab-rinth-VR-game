using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// abrir la puerta activando una antorcha
public class torch_open : MonoBehaviour
{
    public set_color torch_trigger; // delegado antorcha
    // Start is called before the first frame update
    void Start()
    {
        torch_trigger.on_change += open;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    // abrir puerta
    void open() {
        Destroy(gameObject, 3);
    }
}
