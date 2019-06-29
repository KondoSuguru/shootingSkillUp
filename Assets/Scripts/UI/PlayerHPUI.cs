using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHPUI : MonoBehaviour {
    public PlayerHitpoint playerHitpoint;
    Text hpText;
    void Start() {
        hpText = GetComponent<Text>();
    }

    void Update() {
        hpText.text = "HP : " + playerHitpoint.GetHP();
    }
}
