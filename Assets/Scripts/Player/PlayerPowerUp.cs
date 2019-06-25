using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPowerUp : MonoBehaviour {
    public Bullet bullet;
    public TripleShot tripleShot;
    public AudioClip effect;
    int powerUpPoint = 0;
    const int maxPoint = 5;
    int variableMaxPoint = maxPoint;
    bool[] conditionArray;
    BulletGenerate bulletGenerate;
    FloatingBullet floatingBullet;
    PlayerMove playerMove;
    Razer razer;
    AudioSource audioSource;

    private void Start() {
        bulletGenerate = GetComponent<BulletGenerate>();
        floatingBullet = GetComponent<FloatingBullet>();
        playerMove = GetComponent<PlayerMove>();
        razer = GetComponent<Razer>();
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = effect;
        conditionArray = new bool[maxPoint + 1];
        Initialize();
    }
    private void Update() {
        ConditionArrayUpdate();
        PowerUp();
    }

    //プレイヤー強化
    void PowerUp() {
        if (!Input.GetKeyDown(KeyCode.X)) {
            return;
        }
        if (conditionArray[powerUpPoint]) {
            return;
        }

        switch (powerUpPoint) {
            case 1: playerMove.SetSpeed(2f); break;
            case 2: bulletGenerate.SetShotTime(0.02f); break;
            case 3: tripleShot.SetTriple(true); break;
            case 4: razer.SetRazer(true); break;
            case 5: floatingBullet.GenerateOption(); break;
            default: Debug.LogError("PowerUpError"); break;
        }

        audioSource.Play();
        powerUpPoint = 0;
    }

    //すべての初期化
    void Initialize() {
        for (int i = 0; i < conditionArray.Length; i++) {
            conditionArray[i] = false;
        }
        conditionArray[0] = true;

        playerMove.InitSpeed();
        bulletGenerate.InitShotTime();
        bullet.SetTracking(false);
        tripleShot.SetTriple(false);
        razer.SetRazer(false);
        floatingBullet.InitOption();
    }

    //条件配列の更新
    void ConditionArrayUpdate() {
        conditionArray = new bool[maxPoint + 1] { //最初のtrueはダミー
            true, playerMove.IsMaxSpeed(), bulletGenerate.IsMaxShotTime(), /*bullet.GetTracking()*/tripleShot.GetTriple(), razer.GetRazer(), floatingBullet.IsMaxCount(),
        };
    }

    //ポイントの調整
    void Point() {
        for (int i = variableMaxPoint; i != 0; i--) {
            if (!conditionArray[i]) {
                variableMaxPoint = i;
                break;
            }
        }

        if (powerUpPoint >= variableMaxPoint) {
            powerUpPoint = variableMaxPoint;
        }
    }

    private void OnTriggerEnter(Collider other) {
        if (other.tag == "Item") {
            powerUpPoint++;
        }

        ConditionArrayUpdate();
        Point();
    }

    public int GetPowerUpPoint() {
        return powerUpPoint;
    }
    public bool[] GetConditionArray() {
        return conditionArray;
    }
}
