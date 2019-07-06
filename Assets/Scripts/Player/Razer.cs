using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Razer : MonoBehaviour {
    static bool enabledRazer = false;
    CapsuleCollider collider;

    private void Start() {
        collider = GetComponent<CapsuleCollider>();
        transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
    }

    private void Update() {
        transform.localScale += new Vector3(0, 0, 0.3f);
    }

    public void SetRazer(bool set) {
        enabledRazer = set;
    }
    public bool GetRazer() {
        return enabledRazer;
    }

    public void OnTriggerEnter(Collider other) {
        if (other.tag == "BulletDeleteArea") {
            collider.enabled = false;

        }
    }
}
