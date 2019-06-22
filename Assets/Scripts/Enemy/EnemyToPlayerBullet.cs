using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyToPlayerBullet : MonoBehaviour
{
    public float speed = 1.0f;
    private GameObject target;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player");

        transform.LookAt(target.transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;
        pos += transform.TransformDirection(Vector3.forward) * speed;
        transform.position = pos;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "DeleteArea")
        {
            Destroy(gameObject);
        }
    }
}
