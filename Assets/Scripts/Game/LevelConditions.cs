using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LevelConditions : MonoBehaviour
{
    [SerializeField] private int _lives;
    private bool IsLastWave => _enemyController.CurrentWave == _wavesSettings.Waves.Last();

    private EnemyController _enemyController;
    private EnemiesWavesSettings _wavesSettings;

    private void OnEnable()
    {
        _enemyController = GetComponent<EnemyController>();
        _wavesSettings = _enemyController.EnemiesWavesSettings;
        GlobalEventManager.OnEnemyReachedEnd.AddListener(EnemyReachedEnd);
        GlobalEventManager.OnEnemyKilled.AddListener(CheckLevelEnd);
    }

    private void EnemyReachedEnd(Enemy enemy)
    {
        _lives = Mathf.Max(0, _lives - enemy.EnemySettings.Damage);

        CheckLevelEnd();
    }


    private void CheckLevelEnd(Enemy enemy = null)
    {
        if (_lives <= 0)
        {
            GlobalEventManager.SendOnLevelEnd(false);
        }

        if (IsLastWave && _enemyController.AliveEnemies.Count == 1)
        {
            GlobalEventManager.SendOnLevelEnd(true);
        } 
    }
}
