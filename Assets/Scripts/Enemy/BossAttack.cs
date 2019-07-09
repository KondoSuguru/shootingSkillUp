using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttack : MonoBehaviour
{
    private BossHitpoint Hitpoint;
    private int maxHp;
    public GameObject easyBullet;
    public GameObject normalBullet;
    public GameObject hardBullet;
    public GameObject enemyShotBullet;
    public float shotTime = 2.0f; //弾を撃つ間隔（秒）
    private int timer;
    public bool canShot = false;

    enum State
    {
        Easy,
        Normal,
        Hard,
        EnemyShot,
    }
    private State state;

    // Start is called before the first frame update
    void Start()
    {
        Hitpoint = GetComponent<BossHitpoint>();
        maxHp = Hitpoint.GetHp();
        timer = (int)shotTime * 60;
        state = State.Easy;
    }

    // Update is called once per frame
    void Update()
    {
        timer++;
        switch (state)
        {
            case State.Easy:
                EasyUpdate();
                break;
            case State.Normal:
                NormalUpdate();
                break;
            case State.Hard:
                HardUpdate();
                break;
            case State.EnemyShot:
                EnemyShotUpdate();
                break;
        }
            
    }

    void EasyUpdate()
    {
        if (timer >= shotTime * 60)
        {
            Instantiate(easyBullet, transform.position, easyBullet.transform.rotation);
            timer = 0;
        }
        if (Hitpoint.GetHp() <= maxHp * 0.7)
            state = State.EnemyShot;
    }

    void NormalUpdate()
    {
        if (timer >= shotTime * 60)
        {
            Instantiate(normalBullet, transform.position, normalBullet.transform.rotation);
            timer = 0;
        }
        if (Hitpoint.GetHp() <= maxHp * 0.3)
            state = State.EnemyShot;
    }

    void HardUpdate()
    {
        if (timer >= shotTime * 60)
        {
            Instantiate(hardBullet, transform.position, hardBullet.transform.rotation);
            timer = 0;
        }
    }

    void EnemyShotUpdate()
    {
        Instantiate(enemyShotBullet, transform.position, transform.rotation);
        timer = 0;

        if (Hitpoint.GetHp() <= maxHp * 0.3)
            state = State.Hard;
        else if (Hitpoint.GetHp() <= maxHp * 0.7)
            state = State.Normal;
    }
}
