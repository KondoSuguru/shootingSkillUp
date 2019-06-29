using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestoryByTime : MonoBehaviour {
    public float deleteTime;

    private void Start() {
        Destroy(gameObject, deleteTime);
    }
}
