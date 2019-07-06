using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bomb : MonoBehaviour
{
    public float time;
    public float timeout;
    public float destime;
    public float speed;
    public Vector3 dir;
    Rigidbody rb;
    public float power;
    
    public Transform enemy;

    public float a = 10;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        rb.velocity = dir * speed;

        time += Time.deltaTime;

        if (time >= timeout)
        {
            speed = 0;
            rb.AddForce(Shot() * (a * time));
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
