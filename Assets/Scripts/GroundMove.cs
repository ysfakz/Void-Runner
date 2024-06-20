using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundMove : MonoBehaviour {

    [SerializeField] private float walkSpeed = 1f;
    [SerializeField] private float runSpeed = 2f;
    private float currentSpeed;

    private void Start() {
        currentSpeed = walkSpeed;
    }

    private void Update() {
        if (GameManager.Instance.IsRunning()) {
            currentSpeed = runSpeed;
        } else {
            currentSpeed = walkSpeed;
        }

        float distance = currentSpeed * Time.deltaTime;
        GameManager.Instance.IncreaseDistance(distance);

        transform.Translate(Vector3.back * currentSpeed * Time.deltaTime);
    }

    public void PlayerEnter() {
        GameManager.Instance.SetFloor(transform);
    }

    // public void PlayerExit() {
    //     GameManager.Instance.SetFloor(null);
    // }

}
