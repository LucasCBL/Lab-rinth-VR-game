using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//interactuar con objetos
public class interactWithItems : MonoBehaviour
{

    public LayerMask Ignore; // capas a ignorar
    private int grab = Animator.StringToHash("Grabbing"); // animación de la mano
    public Animator anim;
    public Light glow;
    public GameObject on_hand_obj;
    // distancia maxima de agarre
    public float max_distance;
    public bool has_item;
    void Start()
    {

    }

    // Update is called once per frame
    void Update() {
        RaycastHit hit;
 
        // no es necesario fixed update para raycast
        if(Input.GetButtonDown("pickup")) {
            // raycast encuentra todos los objetos en una linea de vista del juador
            if(Physics.Raycast(transform.position, transform.forward, out hit, max_distance, ~Ignore)) {
                print(hit.collider.gameObject.name);
                // si es un objeto para coger lo recoge
                if(hit.collider.gameObject.GetComponent<pickable_item>() && !has_item) {
                    on_hand_obj = hit.collider.gameObject;
                    on_hand_obj.GetComponent<pickable_item>().pickup();
                    pickup();
                    // si es una antorcha o coge el color de la antorcha o usa el color de la antorcha
                } else if(hit.collider.gameObject.GetComponent<pick_color>()) {
                    print("PICK UP TORCH");
                    glow.color = hit.collider.gameObject.GetComponent<pick_color>().get_color();
                } else if(hit.collider.gameObject.GetComponent<set_color>()) {
                    print("LIGHT UP TORCH");
                    hit.collider.gameObject.GetComponent<set_color>().set_fire_color(glow.color);
                } else if(!has_item) {
                    // activa o desactiva la luz
                    glow.enabled = !glow.enabled;
                }
            } else if(!has_item) {
                    glow.enabled = !glow.enabled;
            }
        }
        // suelta el objeto
        if(Input.GetButtonDown("let go")) {
            if(has_item) {
                on_hand_obj.GetComponent<pickable_item>().let_go();
                let_go();
            }
        }
                
    }
    // recoger objeto
    void pickup() {
        glow.enabled = true;
        print("pickup");
        anim.SetTrigger(grab);
        has_item = true;
    }
    // soltar objeto
    void let_go() {
        glow.enabled = false;
        anim.ResetTrigger(grab);
        has_item = false;
    }
}
