using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skybox : MonoBehaviour {

    [SerializeField] private float rotationSpeed = .5f;

    private void Update(){
        transform.Rotate(Vector3.forward, rotationSpeed * Time.deltaTime);
    }

}
