using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMove : MonoBehaviour
{
    public float speed = 1.0f;
    private int counter;
    private int timer;
    private int warpCount;
    public GameObject warpEffect;

    //移動の状態
    public enum Move
    {
        entry,
        left,
        rigth,
        leftWarp,
        rigthWarp,
        centerWarp,
        stay,
    }
    Move move;
    Move previousMove;//前

    // Start is called before the first frame update
    void Start()
    {
        move = Move.entry;
        counter = 0;
        timer = 0;
        warpCount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;

        switch (move)
        {
            case Move.entry:
                MoveEntry(ref pos);
                break;
            case Move.left:
                MoveLeft(ref pos);
                break;
            case Move.rigth:
                MoveRigth(ref pos);
                break;
            case Move.leftWarp:
                MoveLeftWarp(ref pos);
                break;
            case Move.rigthWarp:
                MoveRigthWarp(ref pos);
                break;
            case Move.centerWarp:
                MoveCenterWarp(ref pos);
                break;
            case Move.stay:
                Stay();
                break;
        }

        transform.position = pos;
    }

    void MoveEntry( ref Vector3 position)
    {
        position += new Vector3(0, 0, -speed);
        if (position.z <= 40)
            move = Move.left;
    }

    void MoveLeft(ref Vector3 position)
    {
        position += new Vector3(-speed, 0, 0);
        if (position.x <= -10)
        {
            counter++;
            if (counter >= 3)
            {
                counter = 0;
                Instantiate(warpEffect, new Vector3(10, 0, 10), transform.rotation);

                previousMove = Move.left;
                move = Move.stay;
            }
            else
            {
                move = Move.rigth;
            }
        }
    }

    void MoveRigth(ref Vector3 position)
    {
        position += new Vector3(speed, 0, 0);
        if (position.x >= 10)
        {
            counter++;
            if (counter >= 3)
            {
                counter = 0;
                Instantiate(warpEffect, new Vector3(-10, 0, 10), transform.rotation);
                
                previousMove = Move.rigth;
                move = Move.stay;
            }
            else
            {
                move = Move.left;
            }
        }
    }

    void MoveLeftWarp(ref Vector3 position)
    {

        position = new Vector3(-10, 0, 10);
        timer++;
        if(timer > 60 * 8)
        {
            timer = 0;
            Instantiate(warpEffect, new Vector3(0, 0, 40), transform.rotation);
            previousMove = Move.leftWarp;
            move = Move.stay;
        }
    }
    void MoveRigthWarp(ref Vector3 position)
    {

        position = new Vector3(10, 0, 10);
        timer++;
        if(timer > 60 * 8)
        {
            timer = 0;
            Instantiate(warpEffect, new Vector3(0, 0, 40), transform.rotation);
            previousMove = Move.rigthWarp;
            move = Move.stay;
        }
    }

    void MoveCenterWarp(ref Vector3 position)
    {

        position = new Vector3(0, 0, 40);
        timer++;
        if (timer > 60 * 2)
        {
            timer = 0;
            warpCount++;
            if (warpCount % 2 == 0)
            {
                move = Move.left;
            }
            else
            {
                move = Move.rigth;
            }
        }
    }

    void Stay()
    {
        timer++;
        if(timer > 60 * 2)
        {
            //Instantiate(warpEffect, transform.position, transform.rotation);
            switch (previousMove)
            {
                case Move.left:
                    move = Move.rigthWarp;
                    transform.Rotate(new Vector3(0, 90, 0));
                    break;
                case Move.rigth:
                    move = Move.leftWarp;
                    transform.Rotate(new Vector3(0, 270, 0));
                    break;
                case Move.leftWarp:
                    move = Move.centerWarp;
                    transform.Rotate(new Vector3(0, 90, 0)); ;
                    break;
                case Move.rigthWarp:
                    move = Move.centerWarp;
                    transform.Rotate(new Vector3(0, 270, 0));
                    break;
            }
        }       
    }

    public Move GetMove()
    {
        return move;
    }
}
