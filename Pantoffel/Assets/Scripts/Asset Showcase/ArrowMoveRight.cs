using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowMoveRight : MonoBehaviour {
    // Start is called before the first frame update
    void Start () {

    }

    // Update is called once per frame
    void Update () {
        if (Input.GetKeyDown (KeyCode.RightArrow)) {
            this.transform.Translate (5, 0, 0);
            //transform.Translate (Vector3.left * -1 * Time.deltaTime);
        }
        if (Input.GetKeyDown (KeyCode.LeftArrow)) {
            this.transform.Translate (-5, 0, 0);
            //transform.Translate (Vector3.left * 1 * Time.deltaTime);
        }
    }
}