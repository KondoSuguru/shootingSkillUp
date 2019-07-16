using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {
    public AudioClip se;
    float bulletVelocity = 1f;
    float trackingSpeed = 0.7f;
    float z;
    float x;
    static bool isTracking = false;
    GameObject nearEnemy;
    Vector3 bulletDir;

    private void Start() {
        z = (float)Math.Cos(transform.rotation.eulerAngles.y * Mathf.Deg2Rad);
        x = (float)Math.Sin(transform.rotation.eulerAngles.y * Mathf.Deg2Rad);
        bulletDir = new Vector3(x, 0f, z) * bulletVelocity;
    }

    private void Update() {
        //transform.Translate(transform.TransformDirection(-Vector3.forward * bulletVelocity));
        transform.Translate(bulletDir, Space.World);
        //transform.Translate(transform.InverseTransformDirection(Vector3.forward * speed));
        //transform.localPosition += transform.TransformDirection(Vector3.up * speed);e

        if (tag == "Bullet") {
            transform.Rotate(Vector3.forward, -10f);
        }
    }

    private void OnTriggerEnter(Collider other) {
        //Enemyに触れたら消滅
        if (tag == "Bullet" && other.tag == "Enemy") {
            AudioSource.PlayClipAtPoint(se, Vector3.zero);
            Destroy(gameObject);
        } else if (other.tag == "Enemy" && tag == "Razer") {
            AudioSource.PlayClipAtPoint(se, Vector3.zero);
        }

        if(other.tag == "Shield")
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerExit(Collider other) {
        //BulletDeleteAreaを超えたら消滅
        if (other.tag == "BulletDeleteArea") {
            Destroy(gameObject);
        }
    }

    //一番近いエネミーを走査
    private GameObject SerchMostNearEnemy() {
        GameObject nearEnemy = null;
        float distance = 1000f;

        foreach (var enemy in GameObject.FindGameObjectsWithTag("Enemy")) {
            //弾が敵を通り過ぎてたら無視
            if (transform.position.z > enemy.transform.position.z) {
                break;
            }
            //弾とエネミーの距離がより近ければ更新
            float curDis = Vector3.Distance(transform.position, enemy.transform.position);
            if (curDis < distance) {
                distance = curDis;
                nearEnemy = enemy;
            }
        }

        return nearEnemy;
    }

    //敵を追尾する弾
    private void TrackingShot() {
        nearEnemy = SerchMostNearEnemy();

        if (isTracking && nearEnemy != null) {
            Vector3 p2e = nearEnemy.transform.position - transform.position;
            p2e.Normalize();
            transform.position += new Vector3(p2e.x * trackingSpeed, 0, 0);
        }
    }

    //エネミーの方を向く(未完成)
    void ToEnemyRotate() {
        nearEnemy = SerchMostNearEnemy();

        if (nearEnemy != null) {
            float radian = (float)Math.Atan2(nearEnemy.transform.position.z - transform.position.z, nearEnemy.transform.position.x - transform.position.x);
            transform.Rotate(0, radian, 0);
        } else {
            transform.Rotate(0, 0, 0);
        }
    }

    public void SetTracking(bool set) {
        isTracking = set;
    }
    public bool GetTracking() {
        return isTracking;
    }
    public float GetSpeed() {
        return bulletVelocity;
    }
}
