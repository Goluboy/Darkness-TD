using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildController : MonoBehaviour
{
    [SerializeField] private UIController _UIController; 

    private TurretSpot _turretSpot;

    public TurretSpot TurretSpot 
    {
        get
        {
            return _turretSpot;
        }
        set
        {
            if (value)
                _UIController.SetBuildMenu();
            else
                _UIController.SetEmptyMenu();
            _turretSpot = value;
        }
    }


    public void BuildTurret(Turret turret)
    {
        TurretSpot.Build(turret);
        TurretSpot = null;
    }
}
