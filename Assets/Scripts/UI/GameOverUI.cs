using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameOverUI : MonoBehaviour {

    [SerializeField] private TextMeshProUGUI scoreText;

    private void Update() {
        scoreText.text = Mathf.FloorToInt(GameManager.Instance.GetScore()).ToString();
    }

}
