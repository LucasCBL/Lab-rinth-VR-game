using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// transición a negro para marear menos entre escenas
public class black_transition : MonoBehaviour
{
    public Canvas canvas;
    // Start is called before the first frame update
    void Start()
    {
  
        Invoke(nameof(stop_black), 1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    // desactivar la pantalla negra
    void stop_black() {
        Debug.Log("negro");
        Destroy(canvas.gameObject);
    }
    
}
