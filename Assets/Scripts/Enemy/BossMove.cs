using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMove : MonoBehaviour
{
    public float speed = 1.0f;

    //移動の状態
    enum Move
    {
        down,
        left,
        rigth,
    }
    Move move;

    // Start is called before the first frame update
    void Start()
    {
        move = Move.down;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;

        switch (move)
        {
            case Move.down:
                MoveDown(ref pos);
                break;
            case Move.left:
                MoveLeft(ref pos);
                break;
            case Move.rigth:
                MoveRigth(ref pos);
                break;
        }

        transform.position = pos;
    }

    void MoveDown( ref Vector3 position)
    {
        position += new Vector3(0, 0, -speed);
        if (position.z <= 40)
            move = Move.left;
    }

    void MoveLeft(ref Vector3 position)
    {
        position += new Vector3(speed, 0, 0);
        if (position.x >= 10)
            move = Move.rigth;
    }

    void MoveRigth(ref Vector3 position)
    {
        position += new Vector3(-speed, 0, 0);
        if (position.x <= -10)
            move = Move.left;
    }
}
