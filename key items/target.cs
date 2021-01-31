using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// diana
public class target : MonoBehaviour
{
    public delegate void target_hit();
    public event target_hit activate; // delegado
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void call() {
        activate();
    }
}
