using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicCameraController : MonoBehaviour {
    public float mouseSensitivity = 5.0f;
    public float mouseSmoothing = 2.0f;
    public GameObject playerGameObject;

    private Vector2 mouseLook;
    private Vector2 mouseSmoothV;

    private void Start () {

    }

    private void Update () {
        var mouseDirection = new Vector2 (Input.GetAxisRaw ("Mouse X"), Input.GetAxisRaw ("Mouse Y"));

        mouseDirection = Vector2.Scale (mouseDirection, new Vector2 (mouseSensitivity * mouseSmoothing, mouseSensitivity * mouseSmoothing));
        mouseSmoothV.x = Mathf.Lerp(mouseSmoothV.x, mouseDirection.x, 1f / mouseSmoothing);
        mouseSmoothV.y = Mathf.Lerp(mouseSmoothV.y, mouseDirection.y, 1f / mouseSmoothing);
        mouseLook += mouseSmoothV;

        transform.localRotation = Quaternion.AngleAxis(-mouseLook.y , Vector3.right);
        playerGameObject.transform.localRotation = Quaternion.AngleAxis(mouseLook.x , playerGameObject.transform.up);
    }

}