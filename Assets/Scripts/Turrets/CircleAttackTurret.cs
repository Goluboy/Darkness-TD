using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class CircleAttackTurret : Turret
{
    private List<Enemy> _enemies = new List<Enemy>();

    protected override void Shoot()
    {
        Debug.Log(_enemies.Count);
        _enemies.ForEach(enemy => enemy.GetComponent<Health>().TakeDamage(_turretSettings.BulletDamage));
    }

    protected override void FindNearestEnemy()
    {
        Collider2D[] enemiesInRange = Physics2D.OverlapCircleAll(transform.position, _turretSettings.FireRange);

        _enemies = enemiesInRange.Where(x => x.TryGetComponent(out Enemy enemy)).Select(x => x.GetComponent<Enemy>()).ToList();
        _nearestEnemy = _enemies.FirstOrDefault()?.transform;
    }
}
