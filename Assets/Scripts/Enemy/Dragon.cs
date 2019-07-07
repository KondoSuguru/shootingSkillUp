using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dragon : MonoBehaviour
{
    private int maxCount;
    private int timer;
    public GameObject destroyEffect;

    // Start is called before the first frame update
    void Start()
    {
        maxCount = transform.childCount;
        timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.childCount == 0)
        {
            return;
        }

        if(transform.childCount != maxCount)
        {
            //foreach (Transform n in transform)
            //{
            //    Destroy(n.gameObject);
            //}
            timer++;
            if(timer >= 10)
            {
                Instantiate(destroyEffect, transform.GetChild(0).position, transform.rotation);
                Destroy(transform.GetChild(0).gameObject);
                timer = 0;
            }
        }
    }
}
