using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DoorScript : MonoBehaviour
{
    [SerializeField]
    GameObject door;
    
    private void OnTriggerEnter(Collider other) 
    {
        if (other.CompareTag("Player")){
            Debug.Log("hey!");
        }
    }
}
