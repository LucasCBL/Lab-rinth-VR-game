using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
// pre-selecciona un elemento del menu de botones  para permitir navegarlo con el mando
public class autoselect : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Selectable>().Select();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
