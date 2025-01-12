using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private GameObject _winPanel;
    [SerializeField] private GameObject _losePanel;
    private EnemyController _enemyController;

    private void OnEnable()
    {
        GlobalEventManager.OnLevelEnd.AddListener(OnLevelEnd);
    }

    private void OnLevelEnd(bool isWin)
    {
        if (isWin && _losePanel.activeInHierarchy == false)
        {
            _winPanel.SetActive(true);
        }
        else if (_winPanel.activeInHierarchy == false)
        {
            _losePanel.SetActive(true);
        }
    }
}
