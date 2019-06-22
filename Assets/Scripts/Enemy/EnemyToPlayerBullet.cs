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

        Vector3 vecTarget = target.transform.position - transform.position;
        transform.rotation = Quaternion.LookRotation(vecTarget);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;
        pos += transform.TransformDirection(Vector3.forward) * speed;
        transform.position = pos;
    }
}
