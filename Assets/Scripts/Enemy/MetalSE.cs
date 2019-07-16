using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MetalSE : MonoBehaviour {
    public AudioClip se;

    private void OnTriggerEnter(Collider other) {
        if (other.tag == "Bullet" || other.tag == "Razer") {
            AudioSource.PlayClipAtPoint(se, Vector3.zero);
        }
    }
}
