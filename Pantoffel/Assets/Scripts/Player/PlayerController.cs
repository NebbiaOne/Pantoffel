using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(PlayerMotor))]

public class PlayerController : MonoBehaviour
{
    [SerializeField] 
    private float speed = 5f;
    [SerializeField]
    private float lookSensitivity = 3f;


    private PlayerMotor motor;

     void Start() 
    {
        motor = GetComponent<PlayerMotor>();
        Cursor.lockState = CursorLockMode.Locked;
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

        float _yRot = Input.GetAxisRaw("Mouse X"); // Calculate rotation as a 3D vector: (turning around)

        Vector3 _rotation = new Vector3 (0f, _yRot , 0f) * lookSensitivity;

        motor.Rotate(_rotation); //apply rotation


        float _xRot = Input.GetAxisRaw("Mouse Y"); // Calculate camera rotation as a 3D vector: (turning around)

        float _cameraRotationX = _xRot * lookSensitivity;

        motor.RotateCamera(_cameraRotationX); // apply camera rotation


    }


}
