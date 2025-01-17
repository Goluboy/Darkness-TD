using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemiesWavesSettings", menuName = "Enemy Settings/Enemy Settings")]
public class EnemySettings : ScriptableObject
{
    [SerializeField] private string _name;
    [SerializeField] private Sprite _sprite;
    [SerializeField] private int _reward;
    [SerializeField] private float _speed;
    [SerializeField] private float _health;
    [SerializeField] private int _damage;

    public string Name => _name;
    public Sprite Sprite => _sprite;
    public int Reward => _reward;
    public float Speed => _speed;
    public float Health => _health;
    public int Damage => _damage;
}
