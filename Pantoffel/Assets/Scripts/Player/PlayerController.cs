using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(PlayerMotor))]

public class PlayerController : MonoBehaviour
{
    [SerializeField] 
    private float speed = 5f;


    private PlayerMotor motor;

     void Start() 
    {
        motor = GetComponent<PlayerMotor>();
    }


    void Update() 
    {
        //calculate movement velocity as 3d vector

        float _xMov = Input.GetAxisRaw("Horizontal");
        float _zMov = Input.GetAxisRaw("Vertical");   

        Vector3 _movHorizontal = transform.right * _xMov; // (1,0,0)
        Vector3 _movVertical = transform.forward * _zMov; // (0,0,1)

        Vector3 _velocity = (_movHorizontal + _movVertical).normalized * speed; // Alway get vector with length of 1 -- Final movement vector

        motor.Move(_velocity); //Apply movement


    }


}
