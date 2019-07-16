using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Conami : MonoBehaviour {
    public AudioClip se;
    KeyCode[] conamiCommand;
    int currentNum;
    static bool enabledConami;
    bool playOneSE;


    void Awake() {
        conamiCommand = new KeyCode[] {
            KeyCode.UpArrow, KeyCode.UpArrow, KeyCode.DownArrow, KeyCode.DownArrow, KeyCode.LeftArrow,
            KeyCode.RightArrow, KeyCode.LeftArrow, KeyCode.RightArrow, KeyCode.B, KeyCode.A
        };
        currentNum = 0;
        enabledConami = false;
        playOneSE = true;
    }

    void Update() {
        DownKeyCheck();
        EnabledConami();

        if (GetConami() && playOneSE) {
            AudioSource.PlayClipAtPoint(se, Vector3.zero);
            playOneSE = false;
        }

        Debug.Log(GetConami());
    }

    void DownKeyCheck() {
        if (Input.anyKeyDown) {
            foreach (KeyCode code in Enum.GetValues(typeof(KeyCode))) {
                if (Input.GetKeyDown(code) && conamiCommand[currentNum] == code) {
                    currentNum++;
                    return;
                }
            }
            currentNum = 0;
        }
    }

    private void EnabledConami() {
        enabledConami = currentNum == 10;
    }
    public bool GetConami() {
        return enabledConami;
    }
}
