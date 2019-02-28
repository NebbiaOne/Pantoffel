using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObject : MonoBehaviour {

    public GameObject item;
    public GameObject tempParent;
    public Transform guide;

    // Start is called before the first frame update
    void Start () {
        item.GetComponent<Rigidbody> ().useGravity = true;
    }

    // Update is called once per frame
    void Update () {

    }

    void OnMouseDown () {
        item.GetComponent<Rigidbody> ().useGravity = false;
        item.GetComponent<Rigidbody> ().isKinematic = true;
        item.GetComponent<Collider> ().enabled = false;
        item.transform.position = guide.transform.position;
        item.transform.rotation = guide.transform.rotation;
        item.transform.parent = tempParent.transform;

    }

    void OnMouseUp () {
        item.GetComponent<Rigidbody> ().useGravity = true;
        item.GetComponent<Rigidbody> ().isKinematic = false;
        item.transform.parent = null; //Might need to change this later if object should have other parent eg. currentParent and newParent
        item.transform.position = guide.transform.position;
        item.GetComponent<Collider> ().enabled = true;
    }
}