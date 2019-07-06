using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankEnemyMove : MonoBehaviour
{
    public float speed = 0.1f;

    public Material[] materials;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Renderer>().material = materials[0];
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
        GetComponent<Renderer>().material = materials[1];
    }
}
