using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _stopDistance; // –ассто€ние от цели на котором снар€д исчезает
    [SerializeField] private float _speed;

    private Vector2 _direction;
    private Transform _target;
    private Enemy _targetEnemy;
    private float _damage;

    void FixedUpdate()
    {
        if (_target == null) 
            return;

        Vector2 movement = _direction.normalized * _speed * Time.fixedDeltaTime;
        transform.Translate(movement);

        float distanceToTarget = Vector2.Distance(transform.position, _target.position);

        if (distanceToTarget < _stopDistance)
        {
            TurnOn();
            _targetEnemy.GetComponent<Health>().TakeDamage(_damage);
        }
    }

    public void Shoot(Transform newTarget, Vector3 turretPosition, float speed, float damage)
    {
        _target = newTarget;
        _targetEnemy = newTarget.GetComponent<Enemy>();
        _direction = (newTarget.position - turretPosition).normalized;
        _speed = speed;
        _damage = damage;
    }

    // TODO: object pooling 
    public void TurnOn(bool value = false)
    {
        gameObject.SetActive(value);
    }
}
