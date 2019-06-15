using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    public float speed = 10.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;
        pos.z -= speed;
        transform.position = pos;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "DeleteArea")
        {
            Destroy(gameObject);
        }
    }
}
