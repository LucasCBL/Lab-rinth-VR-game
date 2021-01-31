using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
// Movimiento 
public class movement : MonoBehaviour
{
    private CharacterController controller; // char controllere
    private Vector3 playerVelocity; // velocidad del jugador
    private bool groundedPlayer; // comprueba si el jugador toca el suelo
    public float playerSpeed = 2.0f; // velocidad
    public float jumpHeight = 1.0f; // altura de salto
    private float gravityValue = -9.81f;
    private Camera camera;
    bool mando_profe; // comprueba si el mando es VR BOX (el resto de inputs no estan configurados para ese)
    private void Start()
    {
        mando_profe = Input.GetJoystickNames()[0] == "VR BOX";
        controller = gameObject.GetComponent<CharacterController>();
        camera = Camera.main;
    }
    
    void Update()
    {
        // comproibacion de suelo
        groundedPlayer = controller.isGrounded;
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }
        Vector3 forward = camera.transform.forward;
        Vector3 right = camera.transform.right;
        forward.y = 0;
        right.y = 0;
        Vector3 move;
        if(mando_profe) {
            move = Input.GetAxis("Vertical") * right + Input.GetAxis("Horizontal") * forward;
        } else {
            move = Input.GetAxis("Horizontal") * right + Input.GetAxis("Vertical") * forward;
        }
        
        controller.Move(move * Time.deltaTime * playerSpeed);

       

        // Changes the height position of the player..
        if (Input.GetButton("Jump") && groundedPlayer)
        {
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
        }
        if (Input.GetButton("Cancel")) {
            SceneManager.LoadScene(0);
        }
        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);
    }
}