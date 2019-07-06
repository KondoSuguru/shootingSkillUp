using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudMove : MonoBehaviour
{
    private float speed = 0.3f;

    // Start is called before the first frame update
    void Start()
    {
        Vector3 scale = new Vector3(Random.Range(0.2f, 0.5f), Random.Range(0.2f, 0.5f), 0);
        transform.localScale = scale;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;
        pos += new Vector3(-speed, 0, 0);
        transform.position = pos;

        if(pos.x <= -100)
        {
            Destroy(gameObject);
        }
    }
}
