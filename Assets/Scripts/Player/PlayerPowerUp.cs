﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPowerUp : MonoBehaviour {
    int powerUpCount;
    int maxCount;
    BulletGenerate bulletGenerate;
    FloatingBullet floatingBullet;
    Razer razer;

    private void Start() {
        powerUpCount = 0;
        maxCount = 5;
        bulletGenerate = GetComponent<BulletGenerate>();
        floatingBullet = GetComponent<FloatingBullet>();
        razer = GetComponent<Razer>();
    }

    private void Update() {
        if (powerUpCount >= maxCount) {
            powerUpCount = maxCount;
        }

        PowerUp();
    }

    void PowerUp() {
        if (Input.GetKeyDown(KeyCode.X)) {
            switch (powerUpCount) {
                case 1: bulletGenerate.SetShotTime(0.1f); break;
                case 2: floatingBullet.GenerateOption(); break;
                case 3: razer.SetRazer(true); break;
                case 4: bulletGenerate.SetShotTime(0.1f); break;
                case 5: bulletGenerate.SetShotTime(0.1f); break;
            }
            powerUpCount = 0;
        }
    }

    private void OnTriggerEnter(Collider other) {
        if (other.tag == "Item") {
            powerUpCount++;
        }
    }
}
