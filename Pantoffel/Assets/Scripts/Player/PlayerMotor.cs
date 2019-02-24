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
    private float cameraRotationX = 0f;
    private float currentCameraRotationX = 0f;

    [SerializeField] 
    private float cameraRotationLimit = 85f;
    

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
    public void RotateCamera (float _cameraRotationX)  //Gets a rotational vector for camera
    {
        cameraRotationX = _cameraRotationX;        
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
                currentCameraRotationX -= cameraRotationX; //set rotation and clamp it
                currentCameraRotationX = Mathf.Clamp (currentCameraRotationX, -cameraRotationLimit, cameraRotationLimit);

                cam.transform.localEulerAngles = new Vector3( currentCameraRotationX , 0f, 0f); //apply rotation to transform of camera
            }

        }
    

   


}
