using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterManager : MonoBehaviour {

    [SerializeField] List<GameObject> rocketPrefabs;
    [SerializeField] List<Transform> shooters;
    [SerializeField] private float minSpawnInterval = 2f;
    [SerializeField] private float maxSpawnInterval = 5f;
    private float spawnTimer;

    private void Start() {
        ResetSpawnTimer();
    }

    private void Update() {
        Transform currentFloor = GameManager.Instance.GetFloor();
        if (currentFloor != null && currentFloor == transform) {
            spawnTimer -= Time.deltaTime;
            if (spawnTimer < 0f) {
                ShootRocket();
                ResetSpawnTimer();
            }
        }
    }

    private void ResetSpawnTimer() {
        spawnTimer = Random.Range(minSpawnInterval, maxSpawnInterval);
    }

    private void ShootRocket() {
        if (rocketPrefabs.Count == 0 || shooters.Count == 0) {
            return;
        }

        GameObject currentRocketPrefab = rocketPrefabs[Random.Range(0, rocketPrefabs.Count)];
        Transform currentShooter = shooters[Random.Range(0, shooters.Count)];

        Instantiate(currentRocketPrefab, currentShooter.position, currentShooter.rotation, transform);
        
    }

}
