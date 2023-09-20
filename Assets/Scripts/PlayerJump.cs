using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    /** Declaración de variables */
    [SerializeField] private float jumpForce = 800f; //Fuerza de salto del pj, serializado para modificarlo desde el inspector de unity
    private bool isGrounded; //Variable que chequea si el personaje está pisando un suelo, lo usamos para saber cuándo puede saltar el pj
    private Rigidbody2D rb; //Varaible que servirá de referencia al RigidBody2D del objeto
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); //Obtenemos el RigidBody2D y lo asignamos a rb (ya tenemos la referencia)
    }

    // Update is called once per frame
    void Update()
    {   //Ejecuta la función Jump() si el pj está tocando un suelo y se presiona la tecla de salto
        if (isGrounded && Input.GetButtonDown("Jump")){
            Jump();
        }
    }

    /** Chequeando si hay colisión */
    private void OnCollisionEnter2D(Collision2D collision){
        isGrounded = true;
    }

    private void OnCollisionExit2D(Collision2D collision){
        isGrounded = false;
    }

    /** Declaración de métodos y funciones */

    // Método que actualiza el valor en Y de velocity para representar el salto del pj usando la variable jumpForce declarada al inicio del script
    public void Jump(){
        rb.velocity = new Vector2(rb.velocity.x, jumpForce * Time.deltaTime); ///Multiplicamos la fuerza de salto por el delta time para normalizar el resultado en Y, dejamos el valor en X como está
    }
}
