using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundMove : MonoBehaviour {

    [SerializeField] private float walkSpeed = 1f;
    [SerializeField] private float runSpeed = 3f;
    [SerializeField] private Vector3 despawnPoint = new Vector3(0, 0, -11);
    private float currentSpeed;

    private void Start() {
        currentSpeed = walkSpeed;
    }

    private void Update() {
        if (!GameManager.Instance.IsGamePlaying()) { return; }
        if (GameManager.Instance.IsRunning()) {
            currentSpeed = runSpeed;
        } else {
            currentSpeed = walkSpeed;
        }

        float distance = currentSpeed * Time.deltaTime;
        GameManager.Instance.IncreaseDistance(distance / 10);

        transform.Translate(Vector3.back * currentSpeed * Time.deltaTime);

        CheckPosition();
    }

    private void CheckPosition() {
        if (transform.position.z < despawnPoint.z) {
            DestroySelf();
        }
    }

    public void PlayerEnter() {
        GameManager.Instance.SetFloor(transform);
    }

    private void DestroySelf() {
        GroundSpawner.Instance.DespawnGround();
        Destroy(gameObject);
    }

}
