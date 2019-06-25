using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpItemMove : MonoBehaviour
{
    public float speed = 0.1f;
    public AudioClip effect;
    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = effect;
    }

    // Update is called once per frame
    void Update()
    {

        Vector3 pos = transform.position;
        pos += new Vector3(0, 0, -speed);
        transform.position = pos;

        if (pos.z > 60)
            Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            audioSource.Play();
            Destroy(gameObject);
        }

        if(other.tag == "DeleteArea")
        {
            Destroy(gameObject);
        }
    }
}
