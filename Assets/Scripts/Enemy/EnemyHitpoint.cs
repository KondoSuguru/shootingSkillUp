using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHitpoint : MonoBehaviour
{
    public int hp = 1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(hp <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Bullet")
        {
            hp -= 1;
        }
    }
}
