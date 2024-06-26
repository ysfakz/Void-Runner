using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreCounterUI : MonoBehaviour {

    [SerializeField] private TextMeshProUGUI scoreText;

    private void Update() {
        string multiplier = GameManager.Instance.GetCurrentMultiplier().ToString();
        string score = Mathf.FloorToInt(GameManager.Instance.GetScore()).ToString();

        if (GameManager.Instance.IsMultiplierActive()) {
            scoreText.text = multiplier + "X " + score;
        } else {
            scoreText.text = score;
        }
    }

}
