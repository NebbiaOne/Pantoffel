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
            if (this.transform.position.x < 60) {
                this.transform.Translate (10, 0, 0);

            }
            //transform.Translate (Vector3.left * -1 * Time.deltaTime);
        }
        if (Input.GetKeyDown (KeyCode.LeftArrow)) {
            if (this.transform.position.x > 0) {
                this.transform.Translate (-10, 0, 0);

            }
            //transform.Translate (Vector3.left * 1 * Time.deltaTime);
        }
    }
}