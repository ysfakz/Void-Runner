using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    public static Player Instance { get; private set; }

    public event EventHandler OnPlayerHit;
    private AudioSource audioSource;
    private Animator animator;
    private bool isPaused = false;

    private void Awake() {
        Instance = this;
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    private void Start() {
        GameManager.Instance.OnGamePaused += GameManager_OnGamePaused;
        GameManager.Instance.OnGameUnpaused += GameManager_OnGameUnpaused;
    }

    private void Update() {
        if (GameManager.Instance.IsWaitingToStart()) {
            animator.SetBool("IsWalking", false);
            animator.SetBool("IsRunning", false);
        }
        if (GameManager.Instance.IsGamePlaying()) {
            if (!audioSource.isPlaying) {
                if (isPaused == false) {
                    audioSource.Play();
                }
            }
            if (!GameManager.Instance.IsRunning()) {
                animator.SetBool("IsWalking", true);
                animator.SetBool("IsRunning", false);
            } else {
                animator.SetBool("IsWalking", false);
                animator.SetBool("IsRunning", true);
            }
        }
        if (GameManager.Instance.IsGameOver()) {
            audioSource.Stop();
        }
    }

    private void OnTriggerEnter(Collider other) {
        Rocket rocket = other.gameObject.GetComponent<Rocket>();
        if (rocket != null) {
            OnPlayerHit?.Invoke(this, EventArgs.Empty);
        }
    }

    private void GameManager_OnGamePaused(object sender, EventArgs e) {
        audioSource.Stop();
        isPaused = true;
    }

    private void GameManager_OnGameUnpaused(object sender, EventArgs e) {
        audioSource.Play();
        isPaused = false;
    }

}
