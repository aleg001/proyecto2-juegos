using System.Collections.Generic;
using UnityEngine;

public class FirstPersonMovement : MonoBehaviour
{
    public float speed = 5f;  // Velocidad normal de movimiento

    [Header("Running")]
    public bool canRun = true;  // Define si el personaje puede correr
    public bool IsRunning { get; private set; }  // Estado actual de si el personaje está corriendo
    public float runSpeed = 9f;  // Velocidad al correr
    public KeyCode runningKey = KeyCode.LeftShift;  // Tecla para activar el correr

    private Rigidbody rb;  // Referencia al componente Rigidbody del personaje

    /// <summary> Funciones que pueden sobrescribir la velocidad de movimiento. Usará la última añadida. </summary>
    public List<System.Func<float>> speedOverrides = new List<System.Func<float>>();

    // Inicializa el componente Rigidbody al despertar
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Actualiza la física del personaje cada frame fijo
    void FixedUpdate()
    {
        // Actualiza si el personaje está corriendo según la entrada del usuario
        IsRunning = canRun && Input.GetKey(runningKey);

        // Determina la velocidad de movimiento
        float targetMovingSpeed = IsRunning ? runSpeed : speed;
        if (speedOverrides.Count > 0)
        {
            targetMovingSpeed = speedOverrides[speedOverrides.Count - 1]();  // Aplica la última sobrescritura de velocidad
        }

        // Obtiene la velocidad objetivo a partir de las entradas del jugador (horizontal y vertical)
        Vector2 targetVelocity = new Vector2(Input.GetAxis("Horizontal") * targetMovingSpeed, 
                                             Input.GetAxis("Vertical") * targetMovingSpeed);

        // Aplica el movimiento, manteniendo la velocidad vertical del Rigidbody
        rb.velocity = transform.rotation * new Vector3(targetVelocity.x, rb.velocity.y, targetVelocity.y);
    }
}
