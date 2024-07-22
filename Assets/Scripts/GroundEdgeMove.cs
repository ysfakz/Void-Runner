using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundEdgeMove : MonoBehaviour {

    [SerializeField] private Vector3 despawnPoint = new Vector3(0, 0, -11);
    [SerializeField] private float walkSpeed = 1f;
    [SerializeField] private float runSpeed = 3f;
    private float currentSpeed;

    private void Update() {
        if (!GameManager.Instance.IsGamePlaying()) { return; }
        if (GameManager.Instance.IsRunning()) {
            currentSpeed = runSpeed;
        } else {
            currentSpeed = walkSpeed;
        }

        transform.Translate(Vector3.back * currentSpeed * Time.deltaTime);

        CheckPosition();
    }

    private void CheckPosition() {
        if (transform.position.z < despawnPoint.z) {
            DestroySelf();
        }
    }

    private void DestroySelf() {
        Destroy(gameObject);
    }

}
