using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public static GameManager Instance { get; private set;}
    private float currentScore;

    private void Awake() {
        Instance = this;
    }

    public void IncreaseScore(float amount) {
        currentScore += amount;
    }

    public bool IsRunning() {
        if (Input.GetKey(KeyCode.W)) {
            return true;
        } else {
            return false;
        }
    }

    public float GetScore() {
        return currentScore;
    }

}
