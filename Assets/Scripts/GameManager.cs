using System;
using UnityEngine;

public class GameManager : MonoBehaviour {
    public static GameManager Instance { get; private set;}
    [SerializeField] private float milestoneDistance = 100f;
    [SerializeField] private float multiplier = 3f;
    [SerializeField] private float multiplierDuration = 10f;
    [SerializeField] private WaitingToStartUI waitingToStartUI;
    private float currentScore;
    private float currentDistanceTravelled;
    private float currentMultiplier = 1f;
    private float multiplierTimer;
    private bool isGamePaused = false;
    private Transform currentFloor;
    private const string HIGH_SCORE = "HighScore";
    public event EventHandler OnGamePaused;
    public event EventHandler OnGameUnpaused;
    private enum State {
        WaitingToStart,
        GamePlaying,
        GameOver,
    }
    private State currentState;

    private void Awake() {
        Instance = this;
        currentState = State.WaitingToStart;
    }

    private void Update() {
        AddListeners();
        CheckTimer();

        if (Input.GetKeyDown(KeyCode.Escape) && currentState == State.GamePlaying) {
            TogglePauseGame();
        }

        switch (currentState) {
            case State.WaitingToStart:
                ResumeGame();
                break;
            case State.GamePlaying:
                break;
            case State.GameOver:
                UpdateHighScore();
                PauseGame();
                break;
        }
    }

    private void CheckTimer() {
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

    private void AddListeners() {
        waitingToStartUI.OnStartPressed += WaitingToStartUI_OnStartPressed;
        Player.Instance.OnPlayerHit += Player_OnPlayerHit;
    }

    private void UpdateHighScore() {
        if (currentScore > PlayerPrefs.GetFloat(HIGH_SCORE, 0)) {
            PlayerPrefs.SetFloat(HIGH_SCORE, currentScore);
        }
    }

    public void TogglePauseGame() {
        isGamePaused = !isGamePaused;
        if (isGamePaused) {
            Time.timeScale = 0f;
            OnGamePaused?.Invoke(this, EventArgs.Empty);
        } else {
            Time.timeScale = 1f;
            OnGameUnpaused?.Invoke(this, EventArgs.Empty);
        }
    }

    private void PauseGame() {
        Time.timeScale = 0f;
    }

    private void ResumeGame() {
        Time.timeScale = 1f;
    }

    private void WaitingToStartUI_OnStartPressed(object sender, EventArgs e) {
        currentState = State.GamePlaying;
    }

    private void Player_OnPlayerHit(object sender, EventArgs e) {
        currentState = State.GameOver;
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

    public float GetCurrentMultiplier() {
        return currentMultiplier;
    }

    public bool IsRunning() {
        if (Input.GetKey(KeyCode.W)) {
            return true;
        } else {
            return false;
        }
    }

    public bool IsMultiplierActive() {
        if (currentMultiplier > 1f) {
            return true;
        } else {
            return false;
        }
    }

    public bool IsWaitingToStart() {
        return currentState == State.WaitingToStart;
    }

    public bool IsGamePlaying() {
        return currentState == State.GamePlaying;
    }

    public bool IsGameOver() {
        return currentState == State.GameOver;
    }

}
