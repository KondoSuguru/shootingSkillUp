using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHitpoint : MonoBehaviour
{
    public int hp = 5;
    private bool isInvincible; //無敵状態の判定
    private int invincibleTimer;

    // Start is called before the first frame update
    void Start()
    {
        isInvincible = false;
        invincibleTimer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(hp <= 0)
        {
            Destroy(gameObject);
        }
        if (isInvincible)
        {
            InvincibleUpdate();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Enemy")
        {
            if (isInvincible)
                return;
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
