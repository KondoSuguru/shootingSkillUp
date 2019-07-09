using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomingEnemyMove : MonoBehaviour
{
    private GameObject target;
    public float speed = 1.0f;
    public float rotSpeed = 60.0f;//回転速度
    private bool isStart;//更新をするかどうか

    public Material[] materials;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player");
        isStart = false;
        GetComponent<Renderer>().material = materials[0];
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;

        if (!isStart)
        {
            //pos += new Vector3(0, 0, -speed);
            pos += transform.TransformDirection(Vector3.forward) * speed;
        }
        else
        {
            StartUpdate(ref pos);
        }
        transform.position = pos;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "EnemyStartLine")
        {
            isStart = true;
            GetComponent<Renderer>().material = materials[1];
        }
    }

    private void StartUpdate(ref Vector3 pos)
    {
        if (target.transform.position.z < transform.position.z)
        {
            //ターゲットへのベクトル
            Vector3 vecTarget = target.transform.position - transform.position;
            //自身の正面方向のベクトル
            Vector3 vecForward = transform.TransformDirection(Vector3.forward);
            //ターゲットまでの角度
            float angleDiff = Vector3.Angle(vecForward, vecTarget);
            //回転角度
            float angleAdd = rotSpeed * Time.deltaTime;
            //ターゲットへ向けるクォータニオン
            Quaternion rotTarget = Quaternion.LookRotation(vecTarget);
            if (angleDiff <= angleAdd)
            {
                //回転角度内ならそのまま回転
                transform.rotation = rotTarget;
            }
            else
            {
                //回転角度外ならある程度回転
                float t = angleAdd / angleDiff;
                transform.rotation = Quaternion.Slerp(transform.rotation, rotTarget, t);
            }
        }
        pos += transform.TransformDirection(Vector3.forward) * speed;
    }
}
