using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Razer : MonoBehaviour {
    public GameObject razer;
    Vector3 maxScale = new Vector3(0.1f, 0.1f, 15f);
    static bool enabledRazer = false;

    private void Update() {
        if (!enabledRazer) {
            return;
        }
        ScaleUp();
    }

    void ScaleUp() {
        if (razer.transform.localScale.z >= maxScale.z) {
            razer.transform.localScale = maxScale;
            return;
        }
        razer.transform.localScale += new Vector3(0, 0, 0.3f);
        Debug.Log(razer.transform.localScale);
    }

    public void SetRazer(bool set) {
        enabledRazer = set;
    }
    public bool GetRazer() {
        return enabledRazer;
    }
    public void InitScale() {
        razer.transform.localScale = new Vector3(0.1f, 0.1f, 1f);
    }
}
