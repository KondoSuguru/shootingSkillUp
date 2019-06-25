using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Emitter : MonoBehaviour
{
    public GameObject[] waves;//waveを格納する
    public float[] waveTime;//次waveまでの時間
    private int timer;

    private int currentWave;//現在のwave

    // Start is called before the first frame update
    void Start()
    {
        timer = 0;
        currentWave = 0;
    }

    private void Update()
    {
        timer++;

        if (timer > waveTime[currentWave] * 60)
        {
            Instantiate(waves[currentWave], transform.position, transform.rotation);
            currentWave++;
            timer = 0;
        }
    }
}
