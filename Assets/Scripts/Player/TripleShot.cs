using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TripleShot : MonoBehaviour {
    static bool enabledTriple = false;

    public bool GetTriple() {
        return enabledTriple;
    }
    public void SetTriple(bool set) {
        enabledTriple = set;
    }
}
