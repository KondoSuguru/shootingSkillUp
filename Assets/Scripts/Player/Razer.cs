using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Razer : MonoBehaviour {
    static bool enabledRazer = false;
    BoxCollider boxCollider;

    private void Start() {
        boxCollider = GetComponent<BoxCollider>();
    }

    private void Update() {
        if (!boxCollider.enabled) {
            Destroy(gameObject, 1f);
        }
    }

    public void SetRazer(bool set) {
        enabledRazer = set;
    }
    public bool GetRazer() {
        return enabledRazer;
    }

    public void OnTriggerEnter(Collider other) {
        if (other.tag == "BulletDeleteArea") {
            boxCollider.enabled = false;
        }
    }
}
