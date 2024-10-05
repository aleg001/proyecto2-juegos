using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LVLManager : MonoBehaviour
{
    [SerializeField]
    private Light luz;  // Luz que será controlada


    // Update se llama una vez por frame
    void Update()
    {
        // Si se presiona el botón derecho del ratón (mouse)
        if (Input.GetMouseButtonDown(1))
        {
            // Alterna el estado de la luz (encendido/apagado) de manera más eficiente
            luz.enabled = !luz.enabled;
        }
    }
}
