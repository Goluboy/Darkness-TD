using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "TurretSettings")]
public class TurretSettings : ScriptableObject
{
    [SerializeField] private float _fireRate;
    [SerializeField] private float _fireRange;
    [SerializeField] private LayerMask _enemyLayer;
    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private float _bulletSpeed;
    [SerializeField] private float _bulletDamage;
    [SerializeField] private int _price;

    public float FireRate => _fireRate;
    public float FireRange => _fireRange;
    public LayerMask EnemyLayer => _enemyLayer;
    public GameObject BulletPrefab => _bulletPrefab;
    public float BulletSpeed  => _bulletSpeed;
    public float BulletDamage => _bulletDamage;
    public int Price => _price; 
}
