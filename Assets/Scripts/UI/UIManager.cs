using System;
using UnityEngine;

public class UIManager : MonoBehaviour {

    [SerializeField] private GameObject gameOverUI;

    private void Start() {
        gameOverUI.SetActive(false);
    }

    private void Update() {
        Player.Instance.OnPlayerHit += Player_OnPlayerHit;
    }

    private void Player_OnPlayerHit(object sender, EventArgs e) {
        gameOverUI.SetActive(true);
    }

}
