using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletGenerate : MonoBehaviour {
    public GameObject bullet;
    public GameObject razer;
    public GameObject tripleBullet;
    public GameObject tripleRazer;
    public AudioClip NormalSE;
    public AudioClip RazerSE;
    float time = 0f;
    float shotTime = 0.5f;
    const float defaultShotTime = 0.5f;
    bool canShot = false;
    FloatingBullet floatingBullet;
    TripleShot tripleShot;
    Razer razerScript;
    AudioSource audioSource;

    private void Start() {
        floatingBullet = GetComponent<FloatingBullet>();
        tripleShot = GetComponent<TripleShot>();
        razerScript = razer.GetComponent<Razer>();
        audioSource = GetComponent<AudioSource>();
    }

    private void Update() {
        CanShot();

        if (Input.GetKey(KeyCode.Space) && canShot) {
            canShot = false;
            if (tripleShot.GetTriple() && razerScript.GetRazer()) {
                GenerateBullet(tripleRazer, razer);
            } else if (tripleShot.GetTriple()) {
                GenerateBullet(tripleBullet, bullet);
            } else if (razerScript.GetRazer()) {
                GenerateBullet(razer, razer);
            } else {
                GenerateBullet(bullet, bullet);
            }

            Sound();
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

    void Sound() {
        if (razerScript.GetRazer()) {
            audioSource.PlayOneShot(RazerSE);
        } else {
            audioSource.PlayOneShot(NormalSE);
        }
    }

    //弾の生成
    void GenerateBullet(GameObject playerBullet, GameObject optionBullet) {
        Instantiate(playerBullet, transform.position, transform.rotation);
        for (int i = 0; i < floatingBullet.GetCount(); i++) {
            Instantiate(optionBullet, floatingBullet.GetOptions()[i].transform.position, floatingBullet.GetOptions()[i].transform.rotation);
        }
    }

    public void SetShotTime(float set) {
        shotTime -= set;
        if (shotTime < 0.2f) {
            shotTime = 0.2f;
        }
    }
    public float GetShotTime() {
        return shotTime;
    }
    public bool IsMaxShotTime() {
        return shotTime <= 0.2f ? true : false;
    }
    public void InitShotTime() {
        shotTime = defaultShotTime;
    }
}