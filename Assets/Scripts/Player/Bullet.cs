using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {
    public AudioClip se;
    float speed = 1f;
    float trackingSpeed = 0.7f;
    static bool isTracking = false;
    GameObject nearEnemy;

    private void Start() {
    }

    private void Update() {
        transform.Translate(transform.TransformDirection(-Vector3.forward * speed));
        //transform.position += transform.TransformDirection(Vector3.forward) * speed;
    }

    private void OnTriggerEnter(Collider other) {
        //Enemyに触れたら消滅
        if (other.tag == "Enemy" && tag == "Bullet") {
            AudioSource.PlayClipAtPoint(se, gameObject.transform.position);
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
        return speed;
    }
}
