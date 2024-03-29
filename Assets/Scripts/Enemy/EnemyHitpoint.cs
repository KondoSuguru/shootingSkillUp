﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHitpoint : MonoBehaviour
{
    public int hp = 1;
    public int DropRate = 30;
    public GameObject Item;
    public int score;
    public ScoreUI scoreUI;
    public GameObject destroyEffect;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(hp <= 0)
        {
            //アイテムを落とす
            if(Random.Range(0.0f,100.0f) < DropRate)
            {
                Instantiate(Item, transform.position, Item.transform.rotation);
            }
            Instantiate(destroyEffect, transform.position, transform.rotation);
            Destroy(gameObject);

            scoreUI.SetScore(score);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Bullet" || other.tag == "Razer")
        {
            hp -= 1;
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
