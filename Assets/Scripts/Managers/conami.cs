using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class conami : MonoBehaviour {
    KeyCode[] conamiCommand;
    int currentNum;
    bool enabledConami = false;

    void Awake() {
        conamiCommand = new KeyCode[] {
            KeyCode.UpArrow, KeyCode.UpArrow, KeyCode.DownArrow, KeyCode.DownArrow, KeyCode.LeftArrow,
            KeyCode.RightArrow, KeyCode.LeftArrow, KeyCode.RightArrow, KeyCode.B, KeyCode.A
        };
        currentNum = 0;
    }

    void Update() {
        DownKeyCheck();
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

    public bool EnabledConami() {
        enabledConami = currentNum == 10;
        return enabledConami;
    }
}
