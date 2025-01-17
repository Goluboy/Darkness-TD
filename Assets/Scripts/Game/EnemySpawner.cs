using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private Transform _destinationPoint;
    [SerializeField] private Enemy _basicEnemyPrefab;
    [SerializeField] private Enemy _skeletonEnemyPrefab;

    public Transform DestinationPoint => _destinationPoint;

    public Enemy SpawnEnemy(EnemyType enemyType)
    {
        Enemy enemy = null;

        switch (enemyType)
        {
            case EnemyType.BasicEnemy:
                enemy = Instantiate(_basicEnemyPrefab, transform, this);
                break;
            case EnemyType.SkeletonEnemy:
                enemy = Instantiate(_skeletonEnemyPrefab, transform, this);
                break;
        }

        GlobalEventManager.SendOnEnemySpawn(enemy);

        return enemy;
    }
}
