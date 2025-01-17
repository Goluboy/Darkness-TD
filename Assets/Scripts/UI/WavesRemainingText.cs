using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class WavesRemainingText : MonoBehaviour
{
    [SerializeField] EnemyController _enemyController;

    private TextMeshProUGUI _textMeshProUGUI;

    private void OnEnable()
    {
        GlobalEventManager.OnEnemiesSpawnStart.AddListener(UpdateText);
        GlobalEventManager.OnEnemyWaveStarts.AddListener(UpdateText);
    }

    private void Awake()
    {
        _textMeshProUGUI = GetComponent<TextMeshProUGUI>();
    }

    private void UpdateText(EnemiesWavesSettings enemiesWavesSettings)
    {
        _textMeshProUGUI.text = $"{Array.IndexOf(enemiesWavesSettings.Waves, _enemyController.CurrentWave)}" +
            $"/{enemiesWavesSettings.Waves.Length}";
    }

    private void UpdateText(EnemyWaveSettings enemyWaveSettings)
    {
        Debug.Log(Array.IndexOf(_enemyController.EnemiesWavesSettings.Waves, enemyWaveSettings));
        _textMeshProUGUI.text = $"{Array.IndexOf(_enemyController.EnemiesWavesSettings.Waves, enemyWaveSettings) + 1}" +
            $"/{_enemyController.EnemiesWavesSettings.Waves.Length}";
    }
}
