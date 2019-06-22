using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Razer : MonoBehaviour {
    LineRenderer lineRenderer;

    private void Awake() {
        lineRenderer = GetComponent<LineRenderer>();
    }

    private void Update() {

        if (Input.GetKeyDown(KeyCode.C)) {
            LineScaleUp();
            lineRenderer.enabled = true;
        }
    }

    void LineScaleUp() {
        if (lineRenderer.GetPosition(1).z >= 15f) {
            return;
        }
        lineRenderer.SetPosition(1, new Vector3(transform.position.x, transform.position.y, transform.position.z + 0.001f));
    }

    private void OnTriggerEnter(Collider other) {
        if (other.tag == "BulletDeleteArea") {
            Destroy(gameObject);
        }
    }
}
