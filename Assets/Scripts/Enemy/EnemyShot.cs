using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShot : MonoBehaviour
{
    public GameObject bullet;
    public float shotTime = 2.0f; //弾を撃つ間隔（秒）
    private int timer;
    public bool canShot = false;
    private bool isStart;

    // Start is called before the first frame update
    void Start()
    {
        timer = (int)shotTime * 60;
        isStart = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!canShot || !isStart)
            return;

        timer++;
        if(timer > shotTime * 60)
        {
            Instantiate(bullet, transform.position, transform.rotation);
            timer = 0;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "EnemyStartLine")
        {
            isStart = true;
        }
    }
}
