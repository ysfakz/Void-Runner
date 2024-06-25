using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public event EventHandler OnPlayerHit;
    private Animator animator;

    private void Awake() {
        animator = GetComponent<Animator>();
    }

    private void Update() {
        if (GameManager.Instance.IsWaitingToStart()) {
            animator.SetBool("IsWalking", false);
        }
        if (GameManager.Instance.IsGamePlaying()) {
            animator.SetBool("IsWalking", true);
        }
    }

    private void OnTriggerEnter(Collider other) {
        Rocket rocket = other.gameObject.GetComponent<Rocket>();
        if (rocket != null) {
            OnPlayerHit?.Invoke(this, EventArgs.Empty);
            rocket.gameObject.SetActive(false);
        }
    }

}
