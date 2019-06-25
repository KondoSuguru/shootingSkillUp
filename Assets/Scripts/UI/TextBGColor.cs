using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextBGColor : MonoBehaviour {
    public PlayerPowerUp playerPowerUp;
    Image[] images;

    private void Start() {
        images = GetComponentsInChildren<Image>();
        for (int i = 0; i < images.Length; i++) {
            images[i].color = Color.clear;
        }
    }

    private void Update() {
        for (int i = 0; i < images.Length; i++) {
            if (i == playerPowerUp.GetPowerUpPoint() - 1) {
                images[i].color = Color.red;
            } else {
                images[i].color = Color.clear;
            }
        }

        for (int i = 0; i < images.Length; i++) {
            if (playerPowerUp.GetConditionArray()[i + 1]) {
                images[i].color = Color.black;
            }
        }
    }
}
