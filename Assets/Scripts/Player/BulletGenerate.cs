using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletGenerate : MonoBehaviour {
    public GameObject bullet;
    public float shotTime = 1f;
    float time = 0f;
    bool canShot = false;

    private void Update() {
        if (Input.GetKey(KeyCode.Space) && canShot) {
            // 弾をプレイヤーと同じ位置/角度で作成
            Instantiate(bullet, transform.position, transform.rotation);
            canShot = false;
        }

        CanShot();
    }

    void CanShot() {
        time++;
        //canShot = time >= 60 * shotTime ? true : false;
        if (time >= 60 * shotTime) {
            canShot = true;
            time = 0f;
        }
    }
}