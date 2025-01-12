using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MoneyController : MonoBehaviour
{
    [SerializeField] private int _startMoney;

    public int CurrentMoney
    {
        get
        {
            return _currentMoney;
        }
        private set
        {
            if (_currentMoney != value)
                GlobalEventManager.SendOnMoneyChange();
            _currentMoney = value;
        }
    }

    private int _currentMoney = 100;

    private void Awake()
    {
        GlobalEventManager.OnEnemyKilled.AddListener(EnemyKilled);
    }

    public bool SpendMoney(int amount)
    {
        if (CurrentMoney - amount < 0)
        {
            return false;
        }
        CurrentMoney -= amount;
        return true;
    }

    private void EnemyKilled(Enemy enemy)
    {
        CurrentMoney += enemy.EnemySettings.Reward;
    }
}
