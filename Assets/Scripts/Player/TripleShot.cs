using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TripleShot : MonoBehaviour {
    public Bullet bulletScript;
    Bullet[] bullets;
    static bool enabledTriple = false;

    private void Start() {
        bullets = GetComponentsInChildren<Bullet>();
    }

    private void Update() {
        Debug.Log(enabledTriple);
        if (!enabledTriple) {
            return;
        }

        for (int i = 0; i < bullets.Length; i++) {
            float x = (float)Math.Sin(bullets[i].transform.rotation.y);
            bullets[i].transform.position += new Vector3(x * bulletScript.GetSpeed(), 0, 0);
        }
    }

    public bool GetTriple() {
        return enabledTriple;
    }
    public void SetTriple(bool set) {
        enabledTriple = set;
    }
}
