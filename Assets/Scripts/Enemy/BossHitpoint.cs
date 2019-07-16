using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHitpoint : MonoBehaviour
{
    public int hp = 100;
    public ScoreUI scoreUI;

    public GameObject damageEffect;
    public GameObject destroyEffect;

    private GameObject manager;
    private GamePlayScene playScene;

    // Start is called before the first frame update
    void Start()
    {
        manager = GameObject.FindGameObjectWithTag("PlaySceneManager");
        playScene = manager.GetComponent<GamePlayScene>();
    }

    // Update is called once per frame
    void Update()
    {
        if(hp <= 0 /*|| Input.GetKeyDown(KeyCode.Alpha1)*/)
        {
            Instantiate(destroyEffect, transform.position, transform.rotation);
            scoreUI.SetScore(200);
            //クリアシーンへ遷移
            playScene.Clear();
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Bullet" || other.tag == "Razer")
        {
            hp -= 1;
            Instantiate(damageEffect, transform.position, transform.rotation);
        }

        if (other.gameObject.tag == "DeleteArea")
        {
            Destroy(gameObject);
        }
    }

    public int GetHp()
    {
        return hp;
    }
}
