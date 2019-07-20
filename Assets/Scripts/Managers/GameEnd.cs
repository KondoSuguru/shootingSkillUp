using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEnd : MonoBehaviour {
    void Quit() {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#elif UNITY_STANDALONE
    UnityEngine.Application.Quit();
#endif
    }
    void Update() {
        if (Input.GetKey(KeyCode.Escape))
            Quit();
    }

    //void Update() {
    //    if (Input.GetKeyDown(KeyCode.Escape)) {
    //        UnityEditor.EditorApplication.isPlaying = false;
    //        Application.Quit();
    //    }
    //}
}
