using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour {

    [SerializeField] private float moveSpeed = 4f;

    private void Update() {
        transform.Translate(transform.forward * moveSpeed * Time.deltaTime);
    }

}
