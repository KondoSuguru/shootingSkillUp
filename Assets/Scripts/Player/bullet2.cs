using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet2 : MonoBehaviour
{
    public float speed;
    public Vector3 forward;

    public float time;
    public float timeout;

    public bomb bomb;

    private void Start()
    {
        GetComponent<Rigidbody>().velocity = forward * speed;
    }

    private void Update()
    {
        time += Time.deltaTime;

        if (time >= timeout)
        {
            Bomb();
            Destroy(gameObject);
        }
    }

    void Bomb()
    {
        for (int i = 0; i <= 3; i++)
        {
            bomb = Instantiate(bomb, transform.position, Quaternion.identity);

            if (i == 1){ bomb.dir = new Vector3(10, 0, 10);}
            else if(i == 2) { bomb.dir = new Vector3(-10, 0, -10); }
            else if(i == 3) { bomb.dir = new Vector3(-10, 0, 10); }
            else { bomb.dir = new Vector3(10, 0, -10); }

            bomb.GetComponent<Rigidbody>().velocity = bomb.dir * speed;
        }
    }
}
