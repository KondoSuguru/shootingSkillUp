using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {
    public float speed = 1f;
    public GameObject player;

    private void Start() {
    }

    private void Update() {
        if (Input.GetKey(KeyCode.Z)) {
            TrackingShot();
        } else {
            transform.position += new Vector3(0, 0, speed);
        }
    }

    private void OnTriggerEnter(Collider other) {
        //BulletDeleteAreaに触れたら消滅
        if (other.tag == "BulletDeleteArea") {
            Destroy(gameObject);
        }

        //Enemyに触れたら消滅
        if (other.tag == "Enemy") {
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
        if (SerchMostNearEnemy() != null) {
            Vector3 p2e = SerchMostNearEnemy().transform.position - transform.position;
            p2e.Normalize();
            transform.position += new Vector3(p2e.x * speed, 0, p2e.z * speed);
        }
    }
}
