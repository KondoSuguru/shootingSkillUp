using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGroup : MonoBehaviour
{
    private Vector3 lastEnemyPos;
    public GameObject Item;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.childCount == 2)
        {
            lastEnemyPos = transform.GetChild(0).position;
        }
        else if (transform.childCount == 1)
        {
            lastEnemyPos = transform.GetChild(0).position;
        }

        if(transform.childCount == 0)
        {
            Instantiate(Item, lastEnemyPos, Item.transform.rotation);
            Destroy(gameObject);
        }
    }
}
