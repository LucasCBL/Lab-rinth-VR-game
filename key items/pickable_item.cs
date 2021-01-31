using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// código para objetos recogibles
public class pickable_item : MonoBehaviour
{
    public GameObject onHand; // mano del jugador
    // Start is called before the first frame update
    void Start()
    {
        onHand = GameObject.Find("hand");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    // recoger
    public void pickup() {
        // desactivamos las físicas dl objeto y hacemos que siga al jugador
        GetComponent<Rigidbody>().useGravity = false;
        GetComponent<Rigidbody>().velocity = Vector3.zero;
        GetComponent<Rigidbody>().isKinematic = true;
        this.transform.position = onHand.transform.position;
        this.transform.position -= onHand.transform.up * (this.transform.lossyScale.y - 0.1f);
        this.transform.position += onHand.transform.forward * 0.2f;
        this.transform.parent = GameObject.Find("hand").transform;
    }
    // soltar el objeto
    public void let_go() {
        // reactivamos las físicas del objeto
        Vector3 pos = this.transform.position;
        this.transform.parent = null;
        this.transform.position = pos;
        GetComponent<Rigidbody>().useGravity = true;
        GetComponent<Rigidbody>().isKinematic = false;
        GetComponent<Rigidbody>().velocity = Vector3.zero;
        GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
        
    }
}
