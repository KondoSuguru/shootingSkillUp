using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpItemEffect : MonoBehaviour {
    public BulletGenerate bulletGenerate;

    private void OnTriggerEnter(Collider other) {
        if (other.tag == "Player") {
            bulletGenerate.SetShotTime(0.1f);
            Debug.Log(bulletGenerate.GetShotTime());
        }
    }
}
