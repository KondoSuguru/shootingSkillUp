using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletGenerate : MonoBehaviour {
    public GameObject bullet;
    public FloatingBullet floatingBullet;
    public GameObject razerObj;
    public Razer razerScript;
    public GameObject tripleBullet;
    public TripleShot tripleShot;
    public GameObject tripleRazer;
    float time = 0f;
    float shotTime = 0.5f;
    const float defaultShotTime = 0.5f;
    bool canShot = false;

    private void Start() {
    }

    private void Update() {
        CanShot();

        if (Input.GetKey(KeyCode.Space) && canShot) {
            canShot = false;
            if (tripleShot.GetTriple() && razerScript.GetRazer()) {
                GenerateTripleRazer();
            } else if (tripleShot.GetTriple()) {
                GenerateTriple();
            } else if (razerScript.GetRazer()) {
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
        razerScript.InitScale();
        Instantiate(razerObj, transform.position, transform.rotation);
        for (int i = 0; i < floatingBullet.GetCount(); i++) {
            Instantiate(razerObj, floatingBullet.GetOptions()[i].transform.position, floatingBullet.GetOptions()[i].transform.rotation);
        }
    }
    //トリプルバレット
    void GenerateTriple() {
        Instantiate(tripleBullet, transform.position, transform.rotation);

        for (int i = 0; i < floatingBullet.GetCount(); i++) {
            Instantiate(bullet, floatingBullet.GetOptions()[i].transform.position, floatingBullet.GetOptions()[i].transform.rotation);
        }
    }
    //トリプルレーザー
    void GenerateTripleRazer() {
        razerScript.InitScale();
        Instantiate(tripleRazer, transform.position, transform.rotation);
        for (int i = 0; i < floatingBullet.GetCount(); i++) {
            Instantiate(razerObj, floatingBullet.GetOptions()[i].transform.position, floatingBullet.GetOptions()[i].transform.rotation);
        }
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
        if (shotTime < 0.25f) {
            shotTime = 0.25f;
        }
    }
    public float GetShotTime() {
        return shotTime;
    }
    public bool IsMaxShotTime() {
        return shotTime <= 0.25f ? true : false;
    }
    public void InitShotTime() {
        shotTime = defaultShotTime;
    }
}