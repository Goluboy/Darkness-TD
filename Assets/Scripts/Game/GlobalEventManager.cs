using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GlobalEventManager
{
    public static UnityEvent<Enemy> OnEnemyKilled { get; set; } = new UnityEvent<Enemy>();
    public static UnityEvent<Enemy> OnEnemyReachedEnd { get; set; } = new UnityEvent<Enemy>();
    public static UnityEvent<Enemy> OnEnemySpawn { get; set; } = new UnityEvent<Enemy>();
    public static UnityEvent<EnemyWaveSettings> OnEnemyWaveStarts { get; set; } = new UnityEvent<EnemyWaveSettings>();
    public static UnityEvent<EnemiesWavesSettings> OnEnemiesSpawnStart { get; set; } = new UnityEvent<EnemiesWavesSettings>();
    public static UnityEvent OnMoneyChange { get; set; } = new UnityEvent();
    public static UnityEvent<bool> OnLevelEnd { get; set; } = new UnityEvent<bool>();


    public static void SendOnEnemyKilled(Enemy enemy)
    {
        OnEnemyKilled.Invoke(enemy);
    }

    public static void SendOnEnemyReachedEnd(Enemy enemy)
    {
        OnEnemyReachedEnd.Invoke(enemy);
    }

    public static void SendOnEnemySpawn(Enemy enemy)
    {
        OnEnemySpawn.Invoke(enemy);
    }

    public static void SendOnEnemyWaveStarts(EnemyWaveSettings enemyWaveSettings)
    {
        OnEnemyWaveStarts.Invoke(enemyWaveSettings);
    }
    public static void SendOnEnemiesSpawnStart(EnemiesWavesSettings enemiesWavesSettings)
    {
        OnEnemiesSpawnStart.Invoke(enemiesWavesSettings);
    }

    public static void SendOnMoneyChange() 
    {       
        OnMoneyChange.Invoke(); 
    }

    public static void SendOnLevelEnd(bool isWin) 
    { 
        OnLevelEnd.Invoke(isWin);
    }
}
