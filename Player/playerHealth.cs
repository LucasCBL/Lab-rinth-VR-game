using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

// vida del jugador
public class playerHealth : MonoBehaviour
{
   // Start is called before the first frame update
    
    public int max_health = 5;
    public int actual_health;
    public TextMeshPro text;// texto en la mano para mostrar la vida

    void Start()
    {
        actual_health = max_health;
        text.text = actual_health.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void receive_damage(int damage_val) {
        actual_health -= damage_val;
        text.text = actual_health.ToString();
        if(actual_health <= 0) {
            SceneManager.LoadScene(0);
        }
    }
}
