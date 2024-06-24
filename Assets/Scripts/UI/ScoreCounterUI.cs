using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreCounterUI : MonoBehaviour {

    [SerializeField] private TextMeshProUGUI score;

    private void Update() {
        score.text = Mathf.FloorToInt(GameManager.Instance.GetScore()).ToString();
    }

}
