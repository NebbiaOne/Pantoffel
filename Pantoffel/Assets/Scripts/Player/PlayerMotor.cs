using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]


public class PlayerMotor : MonoBehaviour
{
    private Vector3 velocity = Vector3.zero;

    private Rigidbody rb;

    

    void Start() 
    {
        rb = GetComponent<Rigidbody>();
    }


    public void Move (Vector3 _velocity)  //Gets a movement vector
    {
        velocity = _velocity;
    }

    void FixedUpdate() //run every physics iteration
    {
        PerformMovement();
    }


    void PerformMovement()
    {
        
    }

   


}
