using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot : MonoBehaviour {
    public float speed = 0.01f;
    Rigidbody rb;

    private void Update() {
        //rb.AddForce(speed, 0, 0);
        //rb.velocity += new Vector3(speed, 0, 0);
        transform.position += new Vector3(0, 0, speed);
    }
}
