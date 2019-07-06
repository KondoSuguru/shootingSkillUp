using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    public float speed = 3.0f;

    public float backTime = 2f;
    private int timer;
    private bool isBackMove;
    private bool isStart;
    private float count;

    public Material[] materials;

    enum initPositionLR
    {
        Left,
        Rigth,
    }

    initPositionLR initPosLR;

    // Start is called before the first frame update
    void Start()
    {
        timer = 0;
        count = 0;
        isStart = false;
        isBackMove = false;
        if(transform.position.x > 0)
        {
            initPosLR = initPositionLR.Rigth;
        }
        else
        {
            initPosLR = initPositionLR.Left;
        }
        GetComponent<Renderer>().material = materials[0];
    }

    // Update is called once per frame
    void Update()
    {
        if (isStart)
            timer++;

        if (timer > backTime * 60)
            isBackMove = true;

        Vector3 pos = transform.position;
        if (isBackMove)
        {
            BackMoveUpdate(ref pos);
        }
        else
        {
            pos += transform.TransformDirection(Vector3.forward) * speed;
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

    private void BackMoveUpdate(ref Vector3 position)
    {
        count += 0.01f;

        if (initPosLR == initPositionLR.Rigth)
        {
            position.x -= count;
        }
        else
        {
            position.x += count;
        }
        position.z += count * count * 4;
    }
}
