using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubePlacer : MonoBehaviour
{
    [SerializeField] private List<GameObject> cubePrefabs;
    [SerializeField] private Camera playerCamera;

    private GameObject chosenPrefab;
    private GameObject previousSpawned;
    private GameObject newlySpawned;
    private Vector3[] frustumCorners;
    [HideInInspector] public List<GameObject> spawnedPrefabs;

    void Start() {
        if (playerCamera != null) {
            frustumCorners = new Vector3[4];
            playerCamera.CalculateFrustumCorners(new Rect(0, 0, 1, 1), playerCamera.farClipPlane, Camera.MonoOrStereoscopicEye.Mono, frustumCorners);
            if (ChooseRandomPrefab()) {
                previousSpawned = Instantiate(chosenPrefab, playerCamera.transform.TransformVector(frustumCorners[0]), new Quaternion(0,0,0,0));
                spawnedPrefabs.Add(previousSpawned);
            }
        }
    }

    private bool ChooseRandomPrefab() {
        if (cubePrefabs.Count > 0) {
            chosenPrefab = cubePrefabs[Random.Range(0, cubePrefabs.Count)];
            return (true);
        }
        else {
            return (false);
        }
    }

    private void Update() {
        if (previousSpawned != null) {
            if (previousSpawned.transform.position.x < playerCamera.transform.TransformVector(frustumCorners[3]).x + playerCamera.transform.position.x) {
                if(ChooseRandomPrefab()) {
                    newlySpawned = Instantiate(chosenPrefab, previousSpawned.transform.position, new Quaternion(0,0,0,0));
                    newlySpawned.transform.position = previousSpawned.transform.position + new Vector3(previousSpawned.GetComponent<Renderer>().bounds.size.x / 2, 0, 0) + new Vector3(newlySpawned.GetComponent<Renderer>().bounds.size.x / 2, 0, 0);
                    newlySpawned.GetComponent<Renderer>().material.SetColor("_Color", Random.ColorHSV());
                    previousSpawned = newlySpawned;
                    spawnedPrefabs.Add(previousSpawned);
                }
            }
        }
        foreach (GameObject spawnedPrefab in spawnedPrefabs) {
            if (spawnedPrefab.transform.position.x < playerCamera.transform.TransformVector(frustumCorners[0]).x + playerCamera.transform.position.x) {
                if (spawnedPrefab != null) {
                    Destroy(spawnedPrefab);
                    spawnedPrefabs.Remove(spawnedPrefab);
                }
            }
        }
    }
}
