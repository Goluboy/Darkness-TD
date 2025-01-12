using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Turret : MonoBehaviour
{
    [SerializeField] protected TurretSettings _turretSettings;

    public TurretSettings TurretSettings => _turretSettings;
    public TurretSpot TurretSpot {  get; set; }

    protected float _nextFireTime;
    protected Transform _nearestEnemy;
    protected TurretController _turretController;

    protected virtual void Awake()
    {
        GlobalEventManager.OnEnemyKilled.AddListener(NullNearestEnemy);
        _turretController = FindObjectOfType<TurretController>();
    }

    protected virtual void Update()
    {
        FindNearestEnemy();
        ShootingTick();
    }
       
    protected virtual void Shoot() { }

    protected virtual void FindNearestEnemy() 
    {
        Collider2D[] enemiesInRange = Physics2D.OverlapCircleAll(transform.position, _turretSettings.FireRange);

        if (_nearestEnemy != null && Vector2.Distance(transform.position, _nearestEnemy.position) > _turretSettings.FireRange)
            _nearestEnemy = null;

        foreach (Collider2D collider in enemiesInRange)
        {
            if (collider.TryGetComponent(out Enemy enemy))
            {
                if (!_nearestEnemy)
                    _nearestEnemy = enemy.transform;
            }
        }
    }

    protected virtual void ShootingTick() 
    {
        if (Time.time >= _nextFireTime && _nearestEnemy != null && _nearestEnemy.gameObject.activeSelf)
        {
            Shoot();

            _nextFireTime = Time.time + 1f / _turretSettings.FireRate;
        }
    }

    protected virtual void NullNearestEnemy(Enemy enemy) 
    {
        if (_nearestEnemy != null && _nearestEnemy.gameObject == enemy.gameObject)
            _nearestEnemy = null;
    }

    private void OnMouseDown()
    {
        _turretController.Turret = this;
    }
}
