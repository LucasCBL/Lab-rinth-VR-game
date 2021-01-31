using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// función para puertas abiertas tras matar a enemigos
public class enemies_cleared_open : MonoBehaviour
{
    public int enemy_count;// número de enemigos a matar
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //función publica para que la llamen los enemigos al morir
    public void enemy_death() {
        enemy_count--;
        if(enemy_count <= 0) { // se abre al llegar a 0
            open();
        }
    }
    // abrir puerta
    void open() {
        Destroy(gameObject, 3);
    }
}
