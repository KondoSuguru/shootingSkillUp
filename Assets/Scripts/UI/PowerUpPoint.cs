using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerUpPoint : MonoBehaviour {
    public PlayerPowerUp playerPowerUp;
    Text pointCount;

    private void Start() {
        pointCount = GetComponent<Text>();
        pointCount.text = "Point " + 0;
    }

    private void Update() {
        pointCount.text = "Point " + playerPowerUp.GetPowerUpCount();
    }
}
