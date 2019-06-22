using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletGenerate : MonoBehaviour {
    public GameObject bullet;
    public FloatingBullet floatingBullet;
    float time = 0f;
    float shotTime = 0.5f;
    bool canShot = false;

    private void Update() {
        CanShot();

        if (Input.GetKey(KeyCode.Space) && canShot) {
            // 弾をプレイヤーと同じ位置/角度で作成
            Instantiate(bullet, transform.position, transform.rotation);
            for (int i = 0; i < floatingBullet.GetCount(); i++) {
                Instantiate(bullet, floatingBullet.GetOptions()[i].transform.position, floatingBullet.GetOptions()[i].transform.rotation);
            }
            canShot = false;
        }
    }

    //発射準備
    void CanShot() {
        time += Time.deltaTime;
        if (time >= 0.5f) {
            canShot = true;
            time = 0;
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
}