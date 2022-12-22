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
    private List<GameObject> activeEnemies = new List<GameObject>();
    public GameEvent onWaveEndEvent;

    public void LoadNextWave()
    {
        waveIndex += 1;
        if(waves.Length > waveIndex) {
            currentWave = waves[waveIndex];
        } else {
            // Double the last wave
            int waveDifference = waveIndex + 1 - waves.Length;
            for(int i = 0; i < waveDifference; i++) {
                Invoke("SpawnWave", i);
            }
            return;
        }

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
                activeEnemies.Add(enemy);
            }
        }
    }

    public void HandleEnemyDeath(Component sender, object data)
    {
        if(data is GameObject && activeEnemies.Contains((GameObject) data)) {
            GameObject passedGameObject = (GameObject) data;
            activeEnemies.Remove(passedGameObject);

            if(activeEnemies.Count == 0) {
                
                onWaveEndEvent?.Raise(this, (float) waveIndex + 1);
                LoadNextWave();
            }
        }
    }
}
