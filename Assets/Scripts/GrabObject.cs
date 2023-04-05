using UnityEngine;
using System.Collections;

public class GrabObject : MonoBehaviour {

    GameObject grabbedObject;
    float grabbedObjectSize;

    //pickup object
    void grabObject()
    {
        if (grabbedObject == null)
        {
            return;
        }
        else
        {
            grabbedObject.GetComponent<Rigidbody>().isKinematic = true;
            grabbedObject.transform.parent = Camera.main.transform;
            //this reference needs to be changed in future
            grabbedObject.transform.position = GameObject.Find("Hand").transform.position;
        }
    }

    //drop object
    void dropObject()
    {
        if (grabbedObject == null)
        {
            return;
        }
        else
        {
            grabbedObject.GetComponent<Rigidbody>().isKinematic = false;
            grabbedObject.transform.parent = null;
            grabbedObject.GetComponent<Rigidbody>().AddForce(Camera.main.transform.forward * 700);
            grabbedObject = null;
        }
    }

    //create raycast to object
    GameObject getObject(float range)
    {
        Vector3 objPosition = gameObject.transform.position;
        Vector3 target = objPosition + Camera.main.transform.forward * range;
        RaycastHit hit;
        
        //check if raycast hits something AND if it has a rigidbody component
        if (Physics.Linecast(objPosition, target, out hit) && hit.collider.gameObject.GetComponent<Rigidbody>() != null)
        {
            return hit.collider.gameObject;
        }
        else
        {
            return null;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1) && grabbedObject == null)
        {
            //pick up object
            grabbedObject = getObject(5);
            grabObject();
        }
        if (Input.GetMouseButtonDown(0))
        {
            //drop object
            dropObject();
        }
    }
}
