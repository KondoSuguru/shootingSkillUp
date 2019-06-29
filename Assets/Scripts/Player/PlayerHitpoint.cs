using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHitpoint : MonoBehaviour
{
    public int hp = 5;
    private bool isInvincible; //無敵状態の判定
    private int invincibleTimer;

    private GameObject manager;
    private GamePlayScene playScene;

    public GameObject damageEffect;

    // Start is called before the first frame update
    void Start()
    {
        isInvincible = false;
        invincibleTimer = 0;
        manager = GameObject.FindGameObjectWithTag("PlaySceneManager");
        playScene = manager.GetComponent<GamePlayScene>();
    }

    // Update is called once per frame
    void Update()
    {
        if(hp <= 0)
        {
            //ゲームオーバーシーンに遷移
            playScene.GameOver();
            Destroy(gameObject);
        }
        if (isInvincible)
        {
            InvincibleUpdate();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Enemy" || other.tag == "EnemyBullet")
        {
            if (isInvincible)
                return;
            Instantiate(damageEffect, transform.position, transform.rotation);
            hp -= 1;
            isInvincible = true;
        }
    }

    private void InvincibleUpdate()
    {
        invincibleTimer++;
        GetComponent<Renderer>().material.color = Color.red;
        if(invincibleTimer >= 120)
        {
            invincibleTimer = 0;
            GetComponent<Renderer>().material.color = Color.white;
            isInvincible = false;
        }
    }
}
