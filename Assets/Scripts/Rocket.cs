using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour {

    [SerializeField] private float moveSpeed = 4f;
    [SerializeField] private float lifetime = 10f;

    private void Start() {
        Invoke("DestroySelf", lifetime);
    }

    private void Update() {
        transform.Translate(transform.forward * moveSpeed * Time.deltaTime);
    }

    private void DestroySelf() {
        Destroy(gameObject);
    }

}
