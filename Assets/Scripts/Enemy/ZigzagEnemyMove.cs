using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZigzagEnemyMove : MonoBehaviour
{
    public float speed = 1.0f;
    public float period = 1;//波の周期
    public float amplitude = 1;//振幅
    private int count;
    private bool isStart;//更新をするかどうか

    public Material[] materials;

    // Start is called before the first frame update
    void Start()
    {
        count = 30;
        isStart = false;
        GetComponent<Renderer>().material = materials[0];
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;
        if (!isStart)
        {
            pos += new Vector3(0, 0, -speed);
        }
        else
        {
            count++;
            float x = (float)Math.Sin((Math.PI * 2) / (period * 60) * count) * amplitude;
            pos += new Vector3(x, 0, -speed);
        }
        transform.position = pos;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "EnemyStartLine")
        {
            isStart = true;
            GetComponent<Renderer>().material = materials[1];
        }
    }
}
