using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// proyectil del enemigo
public class enemy_projectile : MonoBehaviour
{
    // Start is called before the first frame update
    public int damage = 1; // daño que hace el proyectil
    void Start()
    {
        Destroy(gameObject, 1.5f); // se destruye a los 1.5 segundos
    }
    // si colisiona con el jugador le hace daño
    private void OnCollisionEnter(Collision other) {
        playerHealth player = other.gameObject.GetComponent<playerHealth>();
        if(player) {
            player.receive_damage(damage);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
