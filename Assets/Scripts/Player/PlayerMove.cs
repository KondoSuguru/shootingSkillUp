using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float speed = 10.0f; //移動速度
    public float forceMultiplier = 50.0f; //移動速度の入力に対する追従度（大きいほどきびきび動く）
    float defaultSpeed = 10f;
    private Rigidbody rb;
    float maxSpeed = 20f;
    //float x = 3;

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
        moveVector.z = Input.GetAxis("Vertical") * speed;
        //moveVector.Normalize();
        rb.AddForce(forceMultiplier * (moveVector - rb.velocity));

        //二次関数
        //x -= 0.05f;
        //transform.position = new Vector3(x, 0.5f, 3 * x * x + 2 * x + 3);
    }

    public void SetSpeed(float set) {
        speed += set;
    }
    public float GetSpeed() {
        return speed;
    }
    public bool IsMaxSpeed() {
        return speed >= maxSpeed ? true : false;
    }
    public void InitSpeed() {
        speed = defaultSpeed;
    }
}
