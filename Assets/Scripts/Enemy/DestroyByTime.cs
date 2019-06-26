using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByTime : MonoBehaviour
{
    public float deleteTime;//消滅する時間(秒)

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, deleteTime);
    }
}
