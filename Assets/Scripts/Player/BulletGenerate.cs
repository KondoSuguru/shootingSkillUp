using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletGenerate : MonoBehaviour {
    public float shotTime = 0.1f;
    public float optionSpeed = 0.3f;
    public GameObject bullet;
    public GameObject option;
    GameObject[] options;
    float time = 0f;
    bool hasOption = false;
    bool canShot = false;


    private void Update() {
        if (Input.GetKey(KeyCode.Space) && canShot) {
            // 弾をプレイヤーと同じ位置/角度で作成
            Instantiate(bullet, transform.position, transform.rotation);
            canShot = false;
        }
        if (Input.GetKeyDown(KeyCode.X)) {
            GenerateOption();
        }

        MoveOption();
        CanShot();
    }

    private void GenerateOption() {
        if (hasOption) {
            return;
        }

        options = new GameObject[2];
        for (int i = 0; i < options.Length; i++) {
            options[i] = Instantiate(option);
        }
        hasOption = true;
    }

    //生成したオプションを指定位置まで動かす
    private void MoveOption() {
        if (!hasOption || options[0].transform.position.y > 4) {
            return;
        }
        Debug.Log(hasOption);

        Vector3 opr = new Vector3(4, 4, transform.position.z) - transform.position;
        opr.Normalize();
        Vector3 opl = new Vector3(-4, 4, transform.position.z) - transform.position;
        opl.Normalize();
        Vector3[] ov = new Vector3[] { opr, opl };

        for (int i = 0; i < options.Length; i++) {
            options[i].transform.position += ov[i] * optionSpeed;
        }
        Debug.Log(options.Length);
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