using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridMove : MonoBehaviour
{
    public float startPosZ;
    public float endPosZ;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;
        pos += new Vector3(0, 0, -speed);
        transform.position = pos;
        if(transform.position.z <= endPosZ)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, startPosZ);
        }
    }
}
