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
            if (powerUpCount == 1 && !bulletGenerate.IsMaxShotTime()) {
                bulletGenerate.SetShotTime(0.1f);
            } else if (powerUpCount == 2 && !floatingBullet.IsMaxCount()) {
                floatingBullet.GenerateOption();
            } else if (powerUpCount == 3 && !razer.GetRazer()) {
                razer.SetRazer(true);
            } else if (powerUpCount == 4 && !bulletGenerate.IsMaxShotTime()) {
                bulletGenerate.SetShotTime(0.1f);
            } else if (powerUpCount == 5 && !bulletGenerate.IsMaxShotTime()) {
                bulletGenerate.SetShotTime(0.1f);
            }
            powerUpCount = 0;
        }
    }

    private void OnTriggerEnter(Collider other) {
        if (other.tag == "Item") {
            powerUpCount++;
        }
    }

    public int GetPowerUpCount() {
        return powerUpCount;
    }
}