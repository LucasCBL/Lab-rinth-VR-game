using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// vida del enemigo
public class health : MonoBehaviour
{
    // Start is called before the first frame update
    public enemies_cleared_open door; // se puede asociar a un enemigo para abrir puertas
    public int max_health = 5; // vida maxima
    public int actual_health;
    void Start()
    {
        actual_health = max_health;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    // recibir daño
    public void receive_damage(int damage_val) {
        actual_health -= damage_val;
        if(actual_health <= 0) {
            death();
            Destroy(gameObject, 0.5f);
        }
    }
    // muerte
    public void death() {
        if(door) {
            door.enemy_death();
        }
    }
}
