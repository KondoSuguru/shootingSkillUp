using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot : MonoBehaviour {
    public float speed = 0.01f;
    Rigidbody rb;

    private void Update() {
        //rb.AddForce(speed, 0, 0);
        //rb.velocity += new Vector3(speed, 0, 0);
        if (Input.GetKey(KeyCode.Z) && SerchMostNearEnemy() != null) {
            Vector3 p2e = SerchMostNearEnemy().transform.position - transform.position;
            p2e.Normalize();
            transform.position += new Vector3(p2e.x * speed, 0, p2e.z * speed);
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
}
