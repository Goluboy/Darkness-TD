using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private float _wavesOffsetInSeconds;
    [SerializeField] private float _enemiesOffsetInSeconds;
    [SerializeField] private EnemySpawner _enemySpawner;
    [SerializeField] private EnemiesWavesSettings _enemyWavesSettings;

    public List<Enemy> AliveEnemies { get; private set; } = new List<Enemy>();
    public EnemyWaveSettings CurrentWave 
    {  
        get
        {
            if (_currentWave == null)
                return _enemyWavesSettings.Waves.FirstOrDefault();
            else
                return _currentWave;
        }
        private set
        {
            _currentWave = value;
        } 
    }

    public EnemySpawner EnemySpawner => _enemySpawner;
    public EnemiesWavesSettings EnemiesWavesSettings => _enemyWavesSettings;

    private EnemyWaveSettings _currentWave;

    private void OnEnable()
    {
        GlobalEventManager.OnLevelEnd.AddListener(LevelEnd);
        GlobalEventManager.OnEnemySpawn.AddListener(EnemySpawned);
        GlobalEventManager.OnEnemyKilled.AddListener(EnemyDespawned);
        GlobalEventManager.OnEnemyReachedEnd.AddListener(EnemyDespawned);
    }

    private void Awake()
    {
        StartCoroutine(LaunchWaves(_enemyWavesSettings));
    }

    public IEnumerator LaunchWaves(EnemiesWavesSettings enemyWave)
    {
        if (enemyWave == null || enemyWave.Waves == null || enemyWave.Waves.Length == 0)
            yield break;

        GlobalEventManager.SendOnEnemiesSpawnStart(enemyWave);
        var enemies = enemyWave.Waves;
        for (int i = 0; i < enemies.Length; i++)
        {
            StartCoroutine(LaunchWave(enemies[i]));
            yield return new WaitForSeconds(_wavesOffsetInSeconds);
        }
    }

    public IEnumerator LaunchWave(EnemyWaveSettings enemyWave)
    {
        if (enemyWave == null || enemyWave.Enemies == null || enemyWave.Enemies.Length == 0)
            yield break;

        var enemies = enemyWave.Enemies;
        CurrentWave = enemyWave;
        for (int i = 0; i < enemies.Length; i++)
        {
            _enemySpawner.SpawnEnemy(enemies[i]);
            yield return new WaitForSeconds(_enemiesOffsetInSeconds);
        }
    }

    private void LevelEnd(bool isWin)
    {
        StopAllCoroutines();
    }

    private void EnemySpawned(Enemy enemy)
    {
        AliveEnemies.Add(enemy);
    }

    private void EnemyDespawned(Enemy enemy)
    {
        AliveEnemies.Remove(enemy);
    }
}
