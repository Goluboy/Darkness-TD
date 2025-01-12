using UnityEngine;

public class Health : MonoBehaviour
{
    private Enemy _enemy;
    private Animator _animator;
    private EnemyDamagedFlash _enemyDamagedFlash;

    public float CurrentHealth { get; private set; }

    void Awake()
    {
        _enemyDamagedFlash = GetComponent<EnemyDamagedFlash>();
        _enemy = GetComponent<Enemy>();
        _animator = GetComponent<Animator>();
        CurrentHealth = _enemy.EnemySettings.Health;
    }

    public void TakeDamage(float damage)
    {
        _enemyDamagedFlash.IsColorChanging = true;

        if (damage > 0 && CurrentHealth > 0)
        {
            CurrentHealth -= damage;
        }

        if (CurrentHealth <= 0)
        {
            _enemy.SetAlive(true);
        }
    }
}
