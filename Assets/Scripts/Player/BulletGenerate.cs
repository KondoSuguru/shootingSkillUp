using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletGenerate : MonoBehaviour {
    public float shotTime = 0.1f;
    public float optionPos = 4f;
    public float optionSpeed = 0.3f;
    public float optionTrackingSpeed = 0.05f;
    public Transform bullet;
    public GameObject option;
    GameObject[] options;
    Vector3[] optionDefaultPos;
    float time = 0f;
    bool hasOption = false;
    bool canShot = false;

    private void Start() {
        options = new GameObject[2];
    }

    private void Update() {
        optionDefaultPos = new Vector3[2] {
            new Vector3(transform.position.x + optionPos, optionPos, transform.position.z), new Vector3(transform.position.x + -optionPos, optionPos, transform.position.z)
            //new Vector3(transform.position.x + optionPos, transform.position.y, transform.position.z), new Vector3(transform.position.x + -optionPos, transform.position.y, transform.position.z)
        };


        if (Input.GetKey(KeyCode.Space) && canShot) {
            // 弾をプレイヤーと同じ位置/角度で作成
            Instantiate(bullet, transform.position, transform.rotation);
            if (hasOption) {
                for (int i = 0; i < options.Length; i++) {
                    Instantiate(bullet, options[i].transform.position, options[i].transform.rotation);
                }
            }
            canShot = false;
        }
        if (Input.GetKeyDown(KeyCode.X)) {
            GenerateOption();
        }

        MoveOption();
        TrackingOptionToPlayer();
        CanShot();
    }

    private void GenerateOption() {
        if (hasOption) {
            return;
        }

        for (int i = 0; i < options.Length; i++) {
            options[i] = Instantiate(option);
        }
        hasOption = true;
    }

    //生成したオプションを指定位置まで動かす
    private void MoveOption() {
        if (!hasOption || options[0].transform.position.y > optionPos) {
            return;
        }

        Vector3 opr = optionDefaultPos[0] - transform.position;
        opr.Normalize();
        Vector3 opl = optionDefaultPos[1] - transform.position;
        opl.Normalize();
        Vector3[] ov = new Vector3[] { opr, opl };

        for (int i = 0; i < options.Length; i++) {
            options[i].transform.position += ov[i] * optionSpeed;
        }
    }

    private void TrackingOptionToPlayer() {
        if (!hasOption) {
            return;
        }

        for (int i = 0; i < options.Length; i++) {
            Vector3 o2odp = optionDefaultPos[i] - options[i].transform.position;
            o2odp.Normalize();
            options[i].transform.position += new Vector3(o2odp.x * optionTrackingSpeed, 0, o2odp.z * optionTrackingSpeed);
        }
    }

    //発射準備
    void CanShot() {
        time++;
        //canShot = time >= 60 * shotTime ? true : false;
        if (time >= 60 * shotTime) {
            canShot = true;
            time = 0f;
        }
    }

    bool GetOption() {
        return hasOption;
    }
    void SetOption(bool set) {
        hasOption = set;
    }
}