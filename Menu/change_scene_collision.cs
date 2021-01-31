using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
// cambio de escena cuando algo entra en un collider
public class change_scene_collision : MonoBehaviour
{

    public int next_scene;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other) {
        load_scene(next_scene);
    }

    void load_scene(int scene) {
        SceneManager.LoadScene(scene);

    }
}
