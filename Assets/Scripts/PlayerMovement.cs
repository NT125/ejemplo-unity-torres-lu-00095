using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    /** Declaración de variables */
    [SerializeField] private float movSpeed = 1250f; //Velocidad de movimiento del pj, serializado para modificarlo desde el inspector de unity
    private bool isFacingRight = true; //Variable que chequea si el pj está mirando a la izq, para controlar la orientación de los sprites
    private Rigidbody2D rb; //Varaible que servirá de referencia al RigidBody2D del objeto

    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>(); //Obtenemos el RigidBody2D y lo asignamos a rb (ya tenemos la referencia)
    }

    // Update is called once per frame
    private void Update()
    {
        float movement = Input.GetAxis("Horizontal"); // Le asignamos a movement lo que devuelva Input.GetAxis(), que será -1 o 1 dependiendo de la entrada recibida

    }

    /** Declaración de métodos y funciones */

    // Método que actualiza el valor de velocidad (velocity) del RigidBody2D, recibe por parámetro un valor flotante que representa la nueva velocidad
    public void Move(float speed){
        rb.velocity = new Vector2(speed * Time.deltaTime, rb.velocity.y); //Multiplicamos la velocidad por el delta time para normalizar el resultado en X, dejamos el valor en Y como está
    }

    // Método que voltea al sprite cambiando la escala en X del componente Transform
    private void Filp(){
        transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.x); //Asignamos a localScale un Vector3 con los mismos valores pero con el valor en X invertido (*-1);
        isFacingRight = !isFacingRight; //Alternamos el valor de isFacingRight
    }
}
