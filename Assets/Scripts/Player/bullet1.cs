using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    public Vector3 forward;
    public float speed;
    public Transform enemy;
    public Player player;
    Rigidbody rb;

    public float time = 0;
    public float destime = 10;

    float g;
    float angle = 30;

    // Update is called once per frame
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        //GetComponent<Rigidbody>().velocity = forward * speed;

        g = 9.8f;
        angle = Random.Range(30, 90);

        Debug.Log(angle);
    }

    private void Update()
    {
        time += Time.deltaTime;

        if (time >= destime)
        {
            Destroy(gameObject);
        }
    }

    private void FixedUpdate()
    {
        Move();
    }

    //ラジアン変換
    float Rad()
    {
        return angle * Mathf.Deg2Rad;
    }

    //三平方の定理
    float Triangle(float x, float y)
    {
        return Mathf.Sqrt(Mathf.Pow(x, 2) + Mathf.Pow(y, 2));
    }

    //プレイヤーと敵の距離を求める
    float Long()
    {
        float x = player.transform.position.x;//プレイヤーのx座標
        float y = player.transform.position.z;//プレイヤーのz座標
        float x1 = enemy.transform.position.x;//敵のx座標
        float y1 = enemy.transform.position.z;//敵のz座標
        //Debug.Log(x);
        //Debug.Log(y);
        //Debug.Log(x1);
        //Debug.Log(y1);

        Vector3 L = new Vector3(x1 - x, 0, y1 - y);
        float l = Triangle(L.x, L.z);
        //Debug.Log(l);
        return l;
    }

    //初速
    float V0()
    {
        float cos = Mathf.Cos(Rad());
        float sin = Mathf.Sin(Rad());
        //Debug.Log(Rad());
        float v0 = Mathf.Sqrt(Long() * g / (2 * sin * cos));
        Debug.Log(v0);
        return v0;
    }

    Vector3 Power()
    {
        float v0 = V0(); //初速
        float x0 = v0 * Mathf.Sin(Rad());
        float y0 = v0 * Mathf.Cos(Rad());
        Vector3 pow = new Vector3(x0, 0, y0);
        return pow;
    }

    void Move()
    {
        Vector3 pow = Power();

        Vector3 force = new Vector3(pow.x - time * g , 0, pow.z );

        rb.AddForce(force);
    }
}
