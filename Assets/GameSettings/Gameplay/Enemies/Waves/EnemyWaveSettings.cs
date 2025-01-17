using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemiesWavesSettings", menuName = "Enemy Settings/Enemy Wave Settings")]
public class EnemyWaveSettings : ScriptableObject
{
    [SerializeField] private EnemyType[] _enemies;
    public EnemyType[] Enemies => _enemies;
}
