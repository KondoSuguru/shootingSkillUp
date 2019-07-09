using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet2 : MonoBehaviour
{
    float speed;
    public Vector3 forward;

    public float time;
    public float timeout;

    public bomb bomb;
    bomb clone;

    float angle = 90;
    float x = 0;//何回繰り返すか(RndBomb)
    float z = 10;//何回繰り返すか(RndBomb)

    private void Start()
    {
        GetComponent<Rigidbody>().velocity = forward * speed;
        speed = 0;
    }

    private void Update()
    {
        time += Time.deltaTime;

        if (time >= timeout)
        {
            RndBomb();
            time = 0;
            x++;
        }
    }

    void CirBomb()
    {
        float angle2 = 7;
        float power = 5;

        angle -= angle2;
        clone = Instantiate(bomb, transform.position, Quaternion.identity);
        bomb.dir = new Vector3(power * Mathf.Cos(Rad(angle)), 0, power * Mathf.Sin(Rad(angle)));
        if (angle <= 90-360)
        {
            Destroy(gameObject);
        }
    }

    void RndBomb()
    {
        for (int i = 0; i < 10; i++)
        {
            float degree = Random.Range(0, 360);
            float power = Random.Range(2, 6);

            clone = Instantiate(bomb, transform.position, Quaternion.identity);
            bomb.dir = new Vector3(power * Mathf.Cos(Rad(degree)), 0, power * Mathf.Sin(Rad(degree)));
        }
        if (x == z)
        {
            Destroy(gameObject);
        }
    }

    //ラジアン変換
    float Rad(float angle)
    {
        return angle * Mathf.Deg2Rad;
    }
}
