using UnityEngine;

public class FirstPersonLook : MonoBehaviour
{
    [SerializeField]
    private Transform character;  // Referencia al personaje
    public float sensitivity = 2f;  // Sensibilidad del ratón
    public float smoothing = 1.5f;  // Suavizado del movimiento

    private Vector2 velocity;  // Velocidad acumulada del movimiento del ratón
    private Vector2 frameVelocity;  // Velocidad calculada por frame

    // Se llama al resetear el componente, asigna el personaje si no está establecido
    void Reset()
    {
        character = GetComponentInParent<FirstPersonMovement>().transform;
    }

    // Se bloquea el cursor al inicio para que no salga de la pantalla del juego
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Actualiza la rotación del personaje y la cámara en cada frame
    void Update()
    {
        // Obtiene el movimiento del ratón y lo ajusta por la sensibilidad
        Vector2 mouseDelta = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));
        Vector2 rawFrameVelocity = mouseDelta * sensitivity;
        frameVelocity = Vector2.Lerp(frameVelocity, rawFrameVelocity, Time.deltaTime * smoothing);  // Suaviza el movimiento
        velocity += frameVelocity;
        velocity.y = Mathf.Clamp(velocity.y, -90f, 90f);  // Limita la rotación vertical

        // Aplica la rotación a la cámara (vertical) y al personaje (horizontal)
        transform.localRotation = Quaternion.AngleAxis(-velocity.y, Vector3.right);
        character.localRotation = Quaternion.AngleAxis(velocity.x, Vector3.up);
    }
}
