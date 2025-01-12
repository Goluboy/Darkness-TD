using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class TurretSpot : MonoBehaviour
{
    [SerializeField] private Transform _parentForTurret;
    [SerializeField] private MoneyController _moneyController;

    private BoxCollider2D _boxCollider;
    private BuildController _buildController;
    private Light2D _light;

    private void Awake()
    {
        _boxCollider = GetComponent<BoxCollider2D>();
        _buildController = _moneyController.GetComponent<BuildController>();
        _light = _buildController.GetComponent<Light2D>();
    }

    public void Build(Turret turretPrefab)
    {
        if (_moneyController.CurrentMoney + 1e-5 >= turretPrefab.TurretSettings.Price)
        {
            bool isValid = _moneyController.SpendMoney(turretPrefab.TurretSettings.Price);
            if (isValid)
            {
                Turret clone = Instantiate(turretPrefab,transform.position, Quaternion.identity, _parentForTurret);
                clone.transform.position = transform.position;
                clone.TurretSpot = this;
                //gameObject.SetActive(false);
                GlobalEventManager.SendOnMoneyChange();
            }
        }        
    }

    private void OnMouseDown()
    {
        _buildController.TurretSpot = this;
    }
}
