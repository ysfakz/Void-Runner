using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour {

    [SerializeField] private float moveSpeed = 4f;
    [SerializeField] private float lifetime = 10f;
    private AudioSource audioSource;

    private void Awake() {
        audioSource = GetComponent<AudioSource>();
    }

    private void Start() {
        Invoke("DestroySelf", lifetime);
        GameManager.Instance.OnGamePaused += GameManager_OnGamePaused;
        GameManager.Instance.OnGameUnpaused += GameManager_OnGameUnpaused;
    }

    private void Update() {
        transform.Translate(transform.forward * moveSpeed * Time.deltaTime);

        if (GameManager.Instance.IsGameOver()) {
            audioSource.Stop();
        }
    }

    private void DestroySelf() {
        Destroy(gameObject);
    }

    private void GameManager_OnGamePaused(object sender, EventArgs e) {
        if (audioSource != null) {
            audioSource.Pause();
        }        
    }

    private void GameManager_OnGameUnpaused(object sender, EventArgs e) {
        if (audioSource != null) {
            audioSource.Play();
        }        
    }

}
