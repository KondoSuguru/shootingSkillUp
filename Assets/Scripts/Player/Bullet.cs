﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {
    float speed = 1f;
    float trackingSpeed = 0.5f;
    static bool isTracking = false;

    private void Update() {
        TrackingShot();
        transform.position += new Vector3(0, 0, speed);
    }

    private void OnTriggerEnter(Collider other) {
        //BulletDeleteAreaに触れたら消滅
        //if (other.tag == "BulletDeleteArea") {
        //    Destroy(gameObject);
        //}

        //Enemyに触れたら消滅
        if (other.tag == "Enemy" && tag == "Bullet") {
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

        foreach (var objs in GameObject.FindGameObjectsWithTag("Enemy")) {
            //弾が敵を通り過ぎてたら無視
            if (transform.position.z > objs.transform.position.z) {
                break;
            }
            //プレイヤーとエネミーの距離がより近ければ更新
            float curDis = Vector3.Distance(transform.position, objs.transform.position);
            if (curDis < distance) {
                distance = curDis;
                nearEnemy = objs;
            }
        }

        return nearEnemy;
    }

    //敵を追尾する弾
    private void TrackingShot() {
        if (!isTracking) {
            return;
        }

        if (SerchMostNearEnemy() != null) {
            Vector3 p2e = SerchMostNearEnemy().transform.position - transform.position;
            p2e.Normalize();
            transform.position += new Vector3(p2e.x * trackingSpeed, 0, 0);
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
