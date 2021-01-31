using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// script de ataque a distancia
public class player_launch_projectile : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject projectile; // proyectil
    // cooldown
    public float timeBetweenAttacks = 1f;
    bool alreadyAttacked = false;
    // fuerza del disparo
    public float force = 30f;
    private Camera camera;

    public interactWithItems player_item; // para saber si el usuario tiene la mano libre
    void Start()
    {

        camera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("let go") && !alreadyAttacked && !player_item.has_item) {
            alreadyAttacked = true;
            Rigidbody rb = Instantiate(projectile, transform.position + camera.transform.forward * 1.5f, Quaternion.identity).GetComponent<Rigidbody>();
            //rb.transform.position += camera.transform.forward * 3;
            rb.AddForce(camera.transform.forward * force, ForceMode.Impulse);
            rb.AddForce(camera.transform.up * 1f, ForceMode.Impulse);
            Invoke(nameof(ResetAttack), timeBetweenAttacks);
        } else if(Input.GetButtonDown("let go") && !alreadyAttacked) {
            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), timeBetweenAttacks);
        }

        
    }
    void ResetAttack() {
        alreadyAttacked = false;
    }
}
