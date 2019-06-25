using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TripleShot : MonoBehaviour {
    public Bullet bulletScript;
    Transform[] bullets;
    static bool enabledTriple = false;

    private void Start() {
        bullets = GetComponentsInChildren<Transform>();
    }

    private void Update() {
        if (!enabledTriple) {
            return;
        }
        if (GetComponentsInChildren<Transform>().Length == 1) { //親オブジェクトだけになったら
            Destroy(gameObject);
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
