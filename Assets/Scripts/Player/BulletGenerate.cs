using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletGenerate : MonoBehaviour {
    public GameObject bullet;
    public FloatingBullet floatingBullet;
    public GameObject razerObj;
    public Razer razerScript;
    float time = 0f;
    float shotTime = 0.5f;
    bool canShot = false;

    private void Update() {
        CanShot();

        if (Input.GetKey(KeyCode.Space) && canShot) {
            canShot = false;
            if (razerScript.GetRazer()) {
                GenerateRazer();
            } else {
                GenerateNormal();
            }
        }
    }

    //発射準備
    void CanShot() {
        if (canShot) {
            return;
        }

        time += Time.deltaTime;
        if (time >= shotTime) {
            canShot = true;
            time = 0;
        }
    }

    //レーザーを生成
    void GenerateRazer() {
        Instantiate(razerObj, transform.position, transform.rotation);
        for (int i = 0; i < floatingBullet.GetCount(); i++) {
            Instantiate(razerObj, floatingBullet.GetOptions()[i].transform.position, floatingBullet.GetOptions()[i].transform.rotation);
        }
        razerScript.InitScale();
    }
    void GenerateNormal() {
        // 弾をプレイヤーと同じ位置/角度で作成
        Instantiate(bullet, transform.position, transform.rotation);
        for (int i = 0; i < floatingBullet.GetCount(); i++) {
            Instantiate(bullet, floatingBullet.GetOptions()[i].transform.position, floatingBullet.GetOptions()[i].transform.rotation);
        }
    }

    public void SetShotTime(float set) {
        shotTime -= set;
        if (shotTime < 0.1f) {
            shotTime = 0.1f;
        }
    }
    public float GetShotTime() {
        return shotTime;
    }
    public bool IsMaxShotTime() {
        return shotTime <= 0.11f ? true : false;
    }
}