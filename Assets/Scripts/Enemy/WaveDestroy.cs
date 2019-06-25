using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveDestroy : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //子要素の数が0になったらwave削除
        if (transform.childCount == 0)
            Destroy(gameObject);
    }
}
