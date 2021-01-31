using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// abrir puerta usando una diana
public class target_open : MonoBehaviour
{
    public target target_trigger; // delegado de la diana
    // Start is called before the first frame update
    void Start()
    {
        target_trigger.activate += open;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    // abrir la puerta
    void open() {
        target_trigger.activate -= open;
        Destroy(gameObject, 3);
    }
}
