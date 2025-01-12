using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private Transform _destinationPoint;
    [SerializeField] private Enemy _basicEnemyPrefab;

    public Transform DestinationPoint => _destinationPoint;

    public Enemy SpawnEnemy(EnemyType enemyType)
    {
        Enemy enemy = null;

        switch (enemyType)
        {
            case EnemyType.BasicEnemy:
                enemy = Instantiate(_basicEnemyPrefab, transform);
                break;
        }

        GlobalEventManager.SendOnEnemySpawn(enemy);

        return enemy;
    }
}
