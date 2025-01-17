using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine.Rendering.Universal;
using UnityEngine;

public class CircleAttackTurret : Turret
{
    [SerializeField] private Light2D _light;
    [SerializeField] private float _maxIntensity;
    private List<Enemy> _enemies = new List<Enemy>();
    private float _targetPoint;
    private bool _isAttacking = false;
    private bool _isReverseAnim = false;


    protected override void Shoot()
    {
        _isAttacking = true;
        Debug.Log(_enemies.Count);
        _enemies.ForEach(enemy => enemy.GetComponent<Health>().TakeDamage(_turretSettings.BulletDamage));
    }

    protected override void FindNearestEnemy()
    {
        Collider2D[] enemiesInRange = Physics2D.OverlapCircleAll(transform.position, _turretSettings.FireRange);

        _enemies = enemiesInRange.Where(x => x.TryGetComponent(out Enemy enemy)).Select(x => x.GetComponent<Enemy>()).ToList();
        _nearestEnemy = _enemies.FirstOrDefault()?.transform;
    }

    new private void Update()
    {
        FindNearestEnemy();
        ShootingTick();
        if (_isAttacking)
            if (!_isReverseAnim)
                Transition(0, _maxIntensity);
            else
                Transition(_maxIntensity, 0);
    }

    private void Transition(float start, float end)
    {
        _targetPoint += Time.deltaTime / 0.3f;
        _light.intensity = Mathf.Lerp(start, end, _targetPoint);
        if (_targetPoint >= 1f)
        {
            _targetPoint = 0;
            _isReverseAnim = !_isReverseAnim;
            if (end == 0f)
            {
                _isAttacking = false;
                return;
            }
        }
    }
}
