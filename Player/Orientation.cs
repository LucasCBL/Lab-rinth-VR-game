using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
// muestra la orientación 
public class Orientation : MonoBehaviour
{
    public TextMeshPro text;
    public string[] directions = {"N", "NE", "E", "SE", "S", "SW", "W", "NW"};
    // Start is called before the first frame update
    void Start()
    {
        Input.location.Start();
        Input.compass.enabled = true;
        // text = GetComponent<TextMeshPro>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(-Input.compass.trueHeading);
        int orientation = (int)((Input.compass.trueHeading - 22.5f) / (360 / (float)(directions.Length)));
        orientation = orientation < 0 ? 0 : orientation;
        text.text = directions[orientation];
    }
}
