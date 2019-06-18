using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public float speed = 1.0f;

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
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "DeleteArea")
        {
            Destroy(gameObject);
        }
    }
}
