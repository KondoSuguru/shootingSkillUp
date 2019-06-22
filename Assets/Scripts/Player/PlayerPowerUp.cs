using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPowerUp : MonoBehaviour {
    public Bullet bullet;
    int powerUpCount;
    int maxCount;
    BulletGenerate bulletGenerate;
    FloatingBullet floatingBullet;
    PlayerMove playerMove;
    Razer razer;

    private void Start() {
        powerUpCount = 0;
        maxCount = 5;
        bulletGenerate = GetComponent<BulletGenerate>();
        floatingBullet = GetComponent<FloatingBullet>();
        playerMove = GetComponent<PlayerMove>();
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
            if (powerUpCount == 1 && !playerMove.IsMaxSpeed()) {
                playerMove.SetSpeed(2f);
            } else if (powerUpCount == 2 && !bulletGenerate.IsMaxShotTime()) {
                bulletGenerate.SetShotTime(0.1f);
            } else if (powerUpCount == 3 && !bullet.GetTracking()) {
                bullet.SetTracking(true);
            } else if (powerUpCount == 4 && !razer.GetRazer()) {
                razer.SetRazer(true);
            } else if (powerUpCount == 5 && !floatingBullet.IsMaxCount()) {
                floatingBullet.GenerateOption();
            } else { //パワーアップ不能ならリターン
                return;
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
