using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObject : MonoBehaviour {

    private float throwForce = 50;
    private float distanceFromPickup;
    private Vector3 objectPos;

    [SerializeField] bool canHold = true;
    [SerializeField] bool isHolding = false;
    public GameObject item;
    public GameObject tempParent;
    public GameObject currentParent;
    //public Transform guide;

    // Start is called before the first frame update
    void Start () {
        item.GetComponent<Rigidbody> ().useGravity = true;
        if (item.transform.parent != null)
        {
        currentParent = item.transform.parent.gameObject;
            
        }else
        {
            currentParent = null;
        }
    }

    // Update is called once per frame
    void Update () {

        distanceFromPickup = Vector3.Distance(item.transform.position, tempParent.transform.position);
        if (distanceFromPickup >= 1f)
        {
            isHolding = false;
        }

        if (isHolding == true) {
            item.GetComponent<Rigidbody>().velocity = Vector3.zero;
            item.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
            item.transform.SetParent (tempParent.transform);
            //item.transform.position = tempParent.transform.position;

            if (Input.GetMouseButtonDown (1)) {
                item.GetComponent<Rigidbody>().AddForce(tempParent.transform.forward * throwForce);
                Debug.Log("Throw clicked");
                isHolding = false;
            }
        } else {
        
            Debug.Log ("THIS IS HAPPENING");
            objectPos = item.transform.position;
            // item.transform.SetParent (null);
            item.GetComponent<Rigidbody> ().useGravity = true;
            item.transform.position = objectPos;
            if (currentParent != null)
            {
                item.transform.SetParent(currentParent.transform);            
            }else
            {
                item.transform.SetParent(null);
            }
        }

    }

    void OnMouseDown () {
        if (distanceFromPickup <= 1f)
        {
            isHolding = true;
            item.GetComponent<Rigidbody> ().useGravity = false;
            item.GetComponent<Rigidbody> ().detectCollisions = true;
            
        }

    }

    void OnMouseUp () {
        isHolding = false;

    }

    // Old system for picking stuff up

    // void OnMouseDown () {
    //     //item.GetComponent<Rigidbody> ().useGravity = false;
    //     item.GetComponent<Rigidbody> ().isKinematic = true;
    //     //item.GetComponent<Collider> ().enabled = false;
    //     item.transform.position = guide.transform.position;
    //     //item.transform.rotation = guide.transform.rotation;
    //     item.transform.parent = tempParent.transform;

    // }

    // void OnMouseUp () {
    //     //item.GetComponent<Rigidbody> ().useGravity = true;
    //     item.GetComponent<Rigidbody> ().isKinematic = false;
    //     item.transform.parent = null; //Might need to change this later if object should have other parent eg. currentParent and newParent
    //     item.transform.position = guide.transform.position;
    //     //item.GetComponent<Collider> ().enabled = true;
    // }
}