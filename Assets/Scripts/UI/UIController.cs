using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

public class UIController : MonoBehaviour
{
    [SerializeField] private GameObject _turretBuildPanel;
    [SerializeField] private GameObject _turretSettingsPanel;

    public void SetBuildMenu()
    {
        _turretBuildPanel.SetActive(true);
        _turretSettingsPanel.SetActive(false);
    }

    public void SetTurretMenu()
    {
        _turretBuildPanel.SetActive(false);
        _turretSettingsPanel.SetActive(true);
    }
    
    public void SetEmptyMenu()
    {
        _turretBuildPanel.SetActive(false);
        _turretSettingsPanel.SetActive(false);
    }
}
