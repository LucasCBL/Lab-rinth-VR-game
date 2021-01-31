using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
// ir al nivel siguiente (código no usado)
public class Nextstage : MonoBehaviour
{
    public int next_scene = 0; // escena siguiente
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    // cambiar de escena cuando el jugador entra en el trigger
    private void OnTriggerEnter(Collider Player) {
        if (Player.gameObject.name == "player") {
            SceneManager.LoadScene (next_scene);
        }
    }
}
