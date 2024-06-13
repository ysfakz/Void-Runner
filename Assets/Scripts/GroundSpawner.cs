using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundSpawner : MonoBehaviour {
    public static GroundSpawner Instance { get; private set; }
    [SerializeField] private List<GameObject> groundPrefabs;
    [SerializeField] private float spawnInterval = 1f;
    private Transform lastSpawnedTransform;

    private void Awake() {
        Instance = this;
    }

    private void Start() {
        StartCoroutine(SpawnGround());
    }

    private IEnumerator SpawnGround() {
        while (true) {
            yield return new WaitForSeconds(spawnInterval);

            int index = Random.Range(0, groundPrefabs.Count);
            GameObject prefabToSpawn = groundPrefabs[index];

            Vector3 spawnPos = Vector3.zero;
            if (lastSpawnedTransform != null) {
                Transform nextspawnPoint = lastSpawnedTransform.Find("NextSpawnPoint");
                if (nextspawnPoint != null) {
                    spawnPos = nextspawnPoint.position;
                }
            }

            GameObject spawnedPrefab = Instantiate(prefabToSpawn, spawnPos, Quaternion.identity);
            lastSpawnedTransform = spawnedPrefab.transform;
        }
    }
}
