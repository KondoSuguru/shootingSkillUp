using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHPUI : MonoBehaviour {
    public PlayerHitpoint playerHitpoint;
    public GameObject pIcon;
    int currentHp;
    int beforeHp;

    void Start() {
        currentHp = playerHitpoint.GetHP();

        for(int i = 0; i < currentHp; i++)
        {
            GameObject icon =  Instantiate(pIcon, new Vector3(30 + 50 * i, 680, 0), transform.rotation);
            icon.transform.parent = transform;
        }
    }

    void Update() {
        beforeHp = currentHp;
        currentHp = playerHitpoint.GetHP();

        if(beforeHp > currentHp)
        {
            Transform im = transform.GetChild(currentHp);
            im.gameObject.GetComponent<Image>().enabled = false;
        }
    }
}
