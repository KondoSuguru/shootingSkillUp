using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteSide : MonoBehaviour {
    float time = 0f;
    float sideDeleteTime = 0.3f;

    void Update() {
        time += Time.deltaTime;
        if (time >= sideDeleteTime) {
            Destroy(gameObject);
        }

        Debug.Log(time);
    }
}
