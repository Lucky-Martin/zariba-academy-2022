using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    [SerializeField] public GameObject enemyContainer;
    [SerializeField] public Wave[] waves;

    private List<GameObject> spawnPoints = new List<GameObject>();
    private int waveIndex = -1;
    private Wave currentWave;

    public void LoadNextWave()
    {
        waveIndex += 1;
        currentWave = waves[waveIndex];
        SpawnWave();
    }

    public void CheckWaveEnded()
    {
        if (enemyContainer.transform.childCount == 0)
        {
            LoadNextWave();
        }
    }
    
    private void Start()
    {
        foreach (Transform child in transform)
        {
            if (child.CompareTag("EnemySpawnPoint"))
            {
                spawnPoints.Add(child.gameObject);
            }
        }
        LoadNextWave();
    }

    private void SpawnWave()
    {
        int enemiesPerSpawnPoint = currentWave.enemyCount / spawnPoints.Count;
        foreach (GameObject spawnPoint in spawnPoints)
        {
            for (int i = 0; i < enemiesPerSpawnPoint; i++)
            {
                var enemy = Instantiate(currentWave.enemyPrefab, spawnPoint.transform.position, Quaternion.identity);
                enemy.transform.parent = enemyContainer.transform;
            }
        }
    }
}
