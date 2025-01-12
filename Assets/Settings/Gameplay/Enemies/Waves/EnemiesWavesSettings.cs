using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemiesWavesSettings", menuName = "Enemy Settings/Enemies Waves Settings")]
public class EnemiesWavesSettings : ScriptableObject
{
    [SerializeField] private EnemyWaveSettings[] _waves;
    public EnemyWaveSettings[] Waves => _waves;
}
