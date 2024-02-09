using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DoorScript : MonoBehaviour
{
    [SerializeField]
    GameObject door;

    // Start is called before the first frame update
    void Start()
    {
        // gameObject.AddComponent<EventTrigger>(); // componente que puede hold eventos
        // EventTrigger.Entry clickEvent = new EventTrigger.Entry;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other) 
    {
        if (other.CompareTag("Player")){
            Debug.Log("hey!");
        }
    }
}
