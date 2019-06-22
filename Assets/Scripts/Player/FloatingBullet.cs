using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingBullet : MonoBehaviour {
    public Transform player;
    public GameObject floatingBullet;
    GameObject[] floatingBullets;
    Vector3[] updatePos;
    const float positionX = 3f;
    //const float positionY = 4f;
    //const float positionZ = -2f;
    const float trackingSpeed = 0.2f;
    const int maxCount = 2;
    static int currentCount = 0;

    private void Start() {
        floatingBullets = new GameObject[maxCount];
        updatePos = new Vector3[maxCount];
    }

    private void Update() {
        UpdatePos();
        //if (Input.GetKeyDown(KeyCode.X)) {
        //    GenerateOption();
        //}
        Move();
    }

    //オプションを生成
    public void GenerateOption() {
        if (currentCount == maxCount) {
            return;
        }

        floatingBullets[currentCount] = Instantiate(floatingBullet, player.transform.position, player.transform.rotation);

        currentCount++;
    }

    //規定の位置まで移動
    void Move() {
        for (int i = 0; i < currentCount; i++) {
            if (Vector3.Distance(updatePos[i], floatingBullets[i].transform.position) < 0.1f/* && updatePos[i].y >= positionY*/) {
                continue;
            }

            Vector3 curPos2updPos = updatePos[i] - floatingBullets[i].transform.position;
            curPos2updPos.Normalize();
            floatingBullets[i].transform.position += curPos2updPos * trackingSpeed;
        }
    }

    //移動すべき場所の更新(一番最初に実行！)
    void UpdatePos() {
        updatePos = new Vector3[maxCount] {
            new Vector3(player.transform.position.x + positionX, player.transform.position.y, player.transform.position.z),
            new Vector3(player.transform.position.x + -positionX, player.transform.position.y, player.transform.position.z),
        };
        //for (int i = 0; i < maxCount; i++) {
        //    updatePos[i] = new Vector3(
        //        (float)Math.Cos(360 / maxCount * i * (float)Math.PI / 180f) * positionY + player.transform.position.x,
        //        (float)Math.Sin(360 / maxCount * i * (float)Math.PI / 180f) * positionY + player.transform.position.y,
        //        player.transform.position.z + positionZ);
        //}
    }

    public int GetCount() {
        return currentCount;
    }
    public GameObject[] GetOptions() {
        return floatingBullets;
    }
    public bool IsMaxCount() {
        return currentCount == maxCount ? true : false;
    }
}
