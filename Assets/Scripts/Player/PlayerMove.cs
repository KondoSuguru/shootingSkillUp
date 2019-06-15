﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float speed = 10.0f; //移動速度
    public float forceMultiplier = 50.0f; //移動速度の入力に対する追従度（大きいほどきびきび動く）
    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 moveVector = Vector3.zero;
        moveVector.x = Input.GetAxis("Horizontal") * speed;
        rb.AddForce(forceMultiplier * (moveVector - rb.velocity));
    }
}