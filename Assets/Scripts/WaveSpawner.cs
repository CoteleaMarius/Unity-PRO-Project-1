using UnityEngine;
using System.Collections;

public class WaveSpawner : MonoBehaviour
{
    [SerializeField] private GameObject enemyA;
    [SerializeField] private Transform spawnPoint;
    [Header("Time between waves")]
    [SerializeField] private float countdown = 3f;   
    [Header("Time between each enemy's spawn")]
    [SerializeField] private float timeBetweenSpawnEnemy = 1f;
    private int _waveNumber = 1;

    private void Start()
    {
        StartCoroutine(SpawnWave());
    }

    private IEnumerator SpawnWave()
    {
        yield return new WaitForSeconds(countdown);
        for (int i = 0; i < _waveNumber; i++)
        {
            Instantiate(enemyA, spawnPoint);
            yield return new WaitForSeconds(timeBetweenSpawnEnemy);
        }

        _waveNumber++;
        StartCoroutine(SpawnWave());
    }

}
