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
    public Transform tempParentChild;
    public GameObject currentParent;

    [SerializeField] Vector3 initOffset;
    //public Transform guide;

    // Start is called before the first frame update
    void Start () {
        item.GetComponent<Rigidbody> ().useGravity = true;

        tempParentChild = tempParent.transform.GetChild(0);

        if (item.transform.parent != null)
        {
        currentParent = item.transform.parent.gameObject;
            
        }else
        {
            currentParent = null;
        }
    }

    // Update is called once per frame
    void FixedUpdate () {

        distanceFromPickup = Vector3.Distance(item.transform.position, tempParent.transform.position);
        if (distanceFromPickup >= 1f)
        {
            isHolding = false;
        }

        if (isHolding == true) {
            item.GetComponent<Rigidbody>().velocity = Vector3.zero;
            item.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
            // item.transform.SetParent (tempParent.transform);
            item.GetComponent<Rigidbody>().position = tempParentChild.position;
            item.GetComponent<Rigidbody>().rotation = tempParentChild.rotation;

            //Debug.DrawLine(tempParent.transform.position, tempParent.transform.position + initOffset);

            if (Input.GetMouseButtonDown (1)) {
                item.GetComponent<Rigidbody>().AddForce(tempParent.transform.forward * throwForce);
                Debug.Log("Throw clicked");
                isHolding = false;
                OnMouseUp();
            }
         } //else {
        
        //     Debug.Log ("THIS IS HAPPENING");
        //     objectPos = item.transform.position;
        //     // item.transform.SetParent (null);
        //     item.GetComponent<Rigidbody> ().useGravity = true;
        //     item.transform.position = objectPos;
        //     if (currentParent != null)
        //     {
        //         item.transform.SetParent(currentParent.transform);            
        //     }else
        //     {
        //         item.transform.SetParent(null);
        //     }
        // }

    }

    void OnMouseDown () {
        if (distanceFromPickup <= 1f)
        {
            isHolding = true;
            item.GetComponent<Rigidbody> ().useGravity = false;
            item.GetComponent<Rigidbody> ().detectCollisions = true;

            tempParentChild.position = item.transform.position;
            tempParentChild.rotation = item.transform.rotation;

            // initOffset = item.transform.position - tempParent.transform.position;
            // initOffset.z = 0;

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 100)){
                Debug.Log("Hit; " + hit.transform.name);
                initOffset = (item.transform.position -hit.point) - (tempParent.transform.position - hit.point);
            }
            
        }

    }

    void OnMouseUp () {
        isHolding = false;
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

    // void OnDrawGizmos()
    // {
    //     Gizmos.DrawSphere(item.transform.position, 0.1f);
    //     Gizmos.DrawLine(item.transform.position, tempParent.transform.position);
    //     Gizmos.DrawSphere(tempParent.transform.position, 0.1f);
    // }

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