using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public static GameManager Instance { get; private set;}

    [SerializeField] private float milestoneDistance = 500f;
    [SerializeField] private float multiplier = 2f;
    [SerializeField] private float multiplierDuration = 10f;

    private float currentScore;
    private float currentDistanceTravelled;
    private float currentMultiplier = 1f;
    private float multiplierTimer;
    private Transform currentFloor;

    private void Awake() {
        Instance = this;
    }

    private void Update() {
        if (multiplierTimer > 0f) {
            multiplierTimer -= Time.deltaTime;
            if (multiplierTimer <= 0f) {
                EndMultiplier();
            }
        }
    }

    public void IncreaseScore(float amount) {
        currentScore += amount * currentMultiplier;
    }

    public void IncreaseDistance(float distance) {
        currentDistanceTravelled += distance;
        IncreaseScore(distance);
        CheckMilestone();
    }

    private void ActivateMultiplier() {
        currentMultiplier = multiplier;
        multiplierTimer = multiplierDuration;
    }

    private void EndMultiplier() {
        currentMultiplier = 1f;
    }

    private void CheckMilestone() {
        float currentMilestone = Mathf.FloorToInt(currentDistanceTravelled / milestoneDistance) * milestoneDistance;

        if (currentMilestone > 0 && currentMilestone % milestoneDistance == 0) {
            ActivateMultiplier();
        }
    }

    public bool IsRunning() {
        if (Input.GetKey(KeyCode.W)) {
            return true;
        } else {
            return false;
        }
    }

    public void SetFloor(Transform floor) {
        currentFloor = floor;
    }

    public Transform GetFloor() {
        return currentFloor;
    }

    public float GetScore() {
        return currentScore;
    }

}
