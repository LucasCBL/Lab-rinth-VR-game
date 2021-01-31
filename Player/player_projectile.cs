using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// proyectil del jugador
public class player_projectile : MonoBehaviour
{
    // Start is called before the first frame update
    public int damage = 1;
    void Start()
    {
        Destroy(gameObject, 1.5f);
    }

    private void OnCollisionEnter(Collision other) {
        health enemy = other.gameObject.GetComponent<health>();
        if(enemy) {
            enemy.receive_damage(damage);
        }
        target tg = other.gameObject.GetComponent<target>();
        if(tg) {
            tg.call();
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
