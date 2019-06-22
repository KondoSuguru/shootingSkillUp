﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Razer : MonoBehaviour {
    public Bullet bullet;
    public GameObject razer;
    Vector3 maxScale = new Vector3(0.1f, 0.1f, 10f);
    bool enabledRazer = false;

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
        razer.transform.localScale += new Vector3(0, 0, 0.1f);
    }

    public void SetRazer(bool set) {
        enabledRazer = set;
    }
    public bool GetRazer() {
        return enabledRazer;
    }
    public void InitScale() {
        razer.transform.localScale = maxScale;
    }
}
