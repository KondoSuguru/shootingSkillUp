using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Razer : MonoBehaviour {
    public GameObject razer;
    public GameObject tripleRazer;
    public TripleShot tripleShot;
    public FloatingBullet floatingBullet;
    Transform[] tripleRazers;
    static bool enabledRazer = false;

    private void Start() {
        tripleRazers = tripleRazer.GetComponentsInChildren<Transform>();
        razer.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
    }

    private void Update() {
        if (!enabledRazer) {
            return;
        }
        ScaleUp();
    }

    void ScaleUp() { //1本か3本かで分岐
        if (enabledRazer || floatingBullet.GetCount() > 0) {
            razer.transform.localScale += new Vector3(0, 0, 0.3f);
        } else {
            for (int i = 0; i < tripleRazers.Length; i++) {
                tripleRazers[i].localScale += new Vector3(0, 0, 0.3f);
            }
        }
    }

    public void SetRazer(bool set) {
        enabledRazer = set;
    }
    public bool GetRazer() {
        return enabledRazer;
    }
}
