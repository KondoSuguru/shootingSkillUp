using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public bullet bullet;
    bullet clone;
    public bullet2 bullet2;
    bullet2 clone2;

    public Vector3 position;

    private void FixedUpdate()
    {
        position = transform.position;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shot();
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            Shot2();
        }
    }

    void Shot()
    {
        clone = Instantiate(bullet, transform.position, Quaternion.identity);
        bullet.forward = transform.forward;
    }

    void Shot2()
    {
        clone2 = Instantiate(bullet2, transform.position, Quaternion.identity);
        bullet2.forward = transform.forward;
    }
}
