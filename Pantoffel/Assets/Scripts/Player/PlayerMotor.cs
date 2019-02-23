using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]


public class PlayerMotor : MonoBehaviour
{
    [SerializeField]
    private Camera cam;
    
    
    private Vector3 velocity = Vector3.zero;
    private Vector3 rotation = Vector3.zero;
    private Vector3 cameraRotation = Vector3.zero;
    

    private Rigidbody rb;

    

    void Start() 
    {
        rb = GetComponent<Rigidbody>();
    }


    public void Move (Vector3 _velocity)  //Gets a movement vector
    {
        velocity = _velocity;        
    }
    public void Rotate (Vector3 _rotation)  //Gets a rotational vector
    {
        rotation = _rotation;        
    }
    public void RotateCamera (Vector3 _cameraRotation)  //Gets a rotational vector for camera
    {
        cameraRotation = _cameraRotation;        
    }

    void FixedUpdate() //run every physics iteration
    {
        PerformMovement();
        PerformRotation();
    }


    void PerformMovement()
    {
        if (velocity != Vector3.zero)
        {
            rb.MovePosition(rb.position + velocity * Time.fixedDeltaTime); //Moves rigidbody to position of player plus velocity vector
        }
    }

    void PerformRotation() //perform rotation
        {
            rb.MoveRotation(rb.rotation * Quaternion.Euler (rotation));
            if (cam != null)
            {
                cam.transform.Rotate (-cameraRotation);
            }

        }
    

   


}
