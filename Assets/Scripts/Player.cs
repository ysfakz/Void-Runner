using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

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
            rocket.gameObject.SetActive(false);
        }
    }

}
