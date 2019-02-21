using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicFPSController : MonoBehaviour {
    public float playerMoveSpeed = 5.0f;

    private float playerHorizontal;
    private float playerVertical;

    void Start ()

    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update () {
        playerVertical = Input.GetAxis ("Vertical") * playerMoveSpeed * Time.deltaTime;
        playerHorizontal = Input.GetAxis ("Horizontal") * playerMoveSpeed * -Time.deltaTime;
        transform.Translate (playerVertical, 0, playerHorizontal);

        if(Input.GetKeyDown("escape"))
        {
            Cursor.lockState = CursorLockMode.None;
        }
    }
}