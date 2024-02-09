using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaperInfo : MonoBehaviour
{
    public GameObject handPoint;
    private GameObject pickedObject = null;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (pickedObject!=null){
            if(Input.GetKey("r")){
                pickedObject.GetComponent<Rigidbody>().useGravity = true;
                pickedObject.GetComponent<Rigidbody>().isKinematic = false;
                pickedObject.gameObject.transform.SetParent(null);
                pickedObject = null;
            }
        }
    }

    private void OnTriggerStay(Collider other) {
        if(other.gameObject.CompareTag("PaperToilet") || other.gameObject.CompareTag("Plunger") || other.gameObject.CompareTag("Atomizer") || other.gameObject.CompareTag("Rags")  ){
            if(Input.GetKey("e") && pickedObject == null){
                other.GetComponent<Rigidbody>().useGravity = false;
                other.GetComponent<Rigidbody>().isKinematic = true;
                other.transform.position = handPoint.transform.position;
                other.transform.localRotation = Quaternion.Euler(0, 90, 0);
                other.gameObject.transform.SetParent(handPoint.gameObject.transform);
                pickedObject = other.gameObject;
            }
        }
    }
}
