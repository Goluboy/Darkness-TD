using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretController : MonoBehaviour
{
    [SerializeField] private UIController _UIController;

    private Turret _turret;

    public Turret Turret
    {
        get
        {
            return _turret;
        }
        set
        {
            if (value)
                _UIController.SetTurretMenu();
            else
                _UIController.SetEmptyMenu();
            _turret = value;
        }
    }

    private MoneyController _moneyController;

    public void DeleteTurret()
    {
        _turret.TurretSpot.gameObject.SetActive(true);
        Destroy(_turret.gameObject);
        Turret = null;
    }
}
