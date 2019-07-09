using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankDestroy : MonoBehaviour
{
    private int maxCount;

    // Start is called before the first frame update
    void Start()
    {
        maxCount = transform.childCount;
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.childCount != maxCount)
        {
            Destroy(gameObject);
        }
    }
}
