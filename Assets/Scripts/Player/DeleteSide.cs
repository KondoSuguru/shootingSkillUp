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

        //var tempColor = GetComponent<Renderer>().materials[0].color;
        //var tempColor2 = GetComponent<Renderer>().materials[1].color;
        //tempColor.a -= 0.05f;
        //tempColor2.a -= 0.05f;
        //GetComponent<Renderer>().materials[0].color = tempColor;
        //GetComponent<Renderer>().materials[1].color = tempColor2;
        //if (GetComponent<Renderer>().materials[0].color.a <= 0f) {
        //    Destroy(gameObject);
        //}
    }
}
