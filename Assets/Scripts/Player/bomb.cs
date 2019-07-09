using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bomb : MonoBehaviour
{
    public float time;
    public float time2;
    public float timeout;
    public float destime;//弾消去までの時間
    public float speed;
    public Vector3 dir;
    Rigidbody rb;
    public float power;
    
    public Transform enemy;

    public float a = 10; //加速度
    float x;//bullet2のどっちのBombかによって変える

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        x = 3;
    }

    private void Update()
    {
        rb.velocity = dir * speed;

        time += Time.deltaTime;

        if (time >= timeout)
        {
            speed = 0;
            
            if (time>=timeout+x)
            {
                time2 += Time.deltaTime;
                rb.AddForce(Shot() * (a * time2));
            }
        }

        if (time >= destime)
        {
            Destroy(gameObject);
        }
    }

    Vector3 Shot()
    {
        float x, y, x1, y1;
        x = transform.position.x;
        y = transform.position.z;
        x1 = enemy.transform.position.x;
        y1 = enemy.transform.position.z;
        
        Vector3 force = new Vector3(x1 - x, 0, y1 - y);
        return force;
    }
}
