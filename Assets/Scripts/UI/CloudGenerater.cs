using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudGenerater : MonoBehaviour
{
    public GameObject[] clouds;
    private int timer;
    private int generateTime;

    // Start is called before the first frame update
    void Start()
    {
        timer = 0;
        generateTime = Random.Range(240, 420);
    }

    // Update is called once per frame
    void Update()
    {
        timer++;

        if(timer > generateTime)
        {
            GameObject cloud = Instantiate(clouds[Random.Range(0, clouds.Length)],
                new Vector3(600, Random.Range(530,720),0),
                transform.rotation);
            cloud.transform.parent = transform;

            timer = 0;
            generateTime = Random.Range(120, 420);
        }
    }
}
