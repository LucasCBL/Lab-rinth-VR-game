using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// funcion para spawnear un objeto(en nuestro caso cubo) con una diana
public class spawn_cube : MonoBehaviour
{
    public GameObject cube; // obejto a spawnear
    public target tg;
    public GameObject spawned_cube; // cubo existente
    // Start is called before the first frame update
    void Start()
    {
        tg.activate += spawn;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    // spawneamos el objeto y eliminamos el que habiamso creado antes
    void spawn() {
        Destroy(spawned_cube);
        spawned_cube = Instantiate(cube, transform.position, Quaternion.identity);
        //Destroy(gameObject, 0);
    }
}
