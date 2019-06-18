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
    MeshRenderer meshRenderer;

    // Start is called before the first frame update
    void Start()
    {
        count = 30;
        isStart = false;
        meshRenderer = GetComponent<MeshRenderer>();
        //RGB値は変えずに透明にする
        //meshRenderer.material.color = new Color(
        //    meshRenderer.material.color.r,
        //    meshRenderer.material.color.g,
        //    meshRenderer.material.color.b,
        //    1.0f);

        Color color = meshRenderer.material.color;
        color.a = 1.0f;
        meshRenderer.material.color = color;
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
            //RGB値は変えずに不透明にする
            //meshRenderer.material.color = new Color(
            //    meshRenderer.material.color.r,
            //    meshRenderer.material.color.g,
            //    meshRenderer.material.color.b,
            //    0.0f);

            Color color = meshRenderer.material.color;
            color.a = 0.0f;
            meshRenderer.material.color = color;
        }
    }
}
