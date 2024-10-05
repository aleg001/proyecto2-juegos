using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaperInfo : MonoBehaviour
{
    public GameObject handPoint;  // Punto de referencia donde los objetos serán mantenidos al ser recogidos
    private GameObject pickedObject = null;  // Almacena el objeto actualmente recogido
    private Rigidbody pickedRigidbody = null; // Almacena el componente Rigidbody del objeto recogido para optimizar el acceso

    // Start se llama antes de la primera actualización del frame
    void Start()
    {
        // No se necesita implementar nada en Start en este caso
    }

    // Update se llama una vez por frame
    void Update()
    {
        // Si hay un objeto recogido
        if (pickedObject != null)
        {
            // Si el jugador presiona la tecla "r", se suelta el objeto
            if (Input.GetKey("r"))
            {
                // Restablece las propiedades físicas del objeto recogido
                pickedRigidbody.useGravity = true;
                pickedRigidbody.isKinematic = false;

                // Desvincula el objeto de la mano y lo suelta
                pickedObject.transform.SetParent(null);
                pickedObject = null;
                pickedRigidbody = null;  // Limpia la referencia al Rigidbody para futuras interacciones
            }
        }
    }

    // Se activa mientras el jugador colisiona con un objeto dentro del trigger
    private void OnTriggerStay(Collider other)
    {
        // Verifica si el objeto es uno de los permitidos (se puede optimizar aún más con un diccionario o lista si es necesario)
        if ((other.gameObject.CompareTag("PaperToilet") || 
            other.gameObject.CompareTag("Plunger") || 
            other.gameObject.CompareTag("Atomizer") || 
            other.gameObject.CompareTag("Rags")) && 
            pickedObject == null)  // Solo recoge el objeto si no hay otro en la mano
        {
            // Si el jugador presiona la tecla "e"
            if (Input.GetKey("e"))
            {
                // Desactiva la gravedad y fija el objeto
                pickedRigidbody = other.GetComponent<Rigidbody>();
                pickedRigidbody.useGravity = false;
                pickedRigidbody.isKinematic = true;

                // Posiciona el objeto en el punto de la mano y ajusta la rotación
                other.transform.position = handPoint.transform.position;
                other.transform.localRotation = Quaternion.Euler(0, 90, 0);

                // Vincula el objeto a la mano
                other.transform.SetParent(handPoint.transform);

                // Almacena el objeto recogido
                pickedObject = other.gameObject;
            }
        }
    }
}
