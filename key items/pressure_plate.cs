using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// placa de presión
public class pressure_plate : MonoBehaviour
{
    // parámetrs animacion
    Animator anim;
    int pressed = Animator.StringToHash("pressed");
    // puerta
    public pressure_plates_door door;
    private int objects = 0;
    // Start is called before the first frame update
    void Start()
    {
        anim =  transform.parent.gameObject.GetComponent<Animator>();
    }
    // en caso de colisión ativamos la animación de presionada y llamamos a la función de la puerta
    private void OnCollisionEnter(Collision other) {
        print("enter");
        pickable_item item = other.gameObject.GetComponent<pickable_item>();
        if(item) {
            if(objects == 0) {
                anim.SetTrigger(pressed);
                door.add_plate();
            }
            objects++;
        }
        
    }
    // si se deja de presionar la puerta avisamos a la puerta
    private void OnCollisionExit(Collision other) {
        print("exit");
        objects--;
        if(objects == 0) {
            anim.ResetTrigger(pressed);
            door.subtract_plate();
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
