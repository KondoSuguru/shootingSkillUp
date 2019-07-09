using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHitpoint : MonoBehaviour
{
    public int hp = 5;
    public AudioClip se;
    public GameObject damageEffect;
    public Material material;

    private bool isInvincible; //無敵状態の判定
    private int invincibleTimer;

    private GameObject manager;
    private GamePlayScene playScene;
    private AudioSource audioSource;


    // Start is called before the first frame update
    void Start()
    {
        isInvincible = false;
        invincibleTimer = 0;
        manager = GameObject.FindGameObjectWithTag("PlaySceneManager");
        playScene = manager.GetComponent<GamePlayScene>();
        audioSource = GetComponent<AudioSource>();
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

            audioSource.PlayOneShot(se);
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
            GetComponent<Renderer>().material = material;
            isInvincible = false;
        }
    }

    public int GetHP() {
        return hp;
    }
}
