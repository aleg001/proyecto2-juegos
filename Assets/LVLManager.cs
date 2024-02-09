using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LVLManager : MonoBehaviour
{
    //propiedades
    // public Text tag_objeto;
    [SerializeField]
    Light luz;
    // AudioSource linterna;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            luz.enabled = luz.enabled ? false : true;
            //linterna.Play();
        }
    }
}
