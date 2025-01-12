using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(TextMeshProUGUI))]
public class MoneyText : MonoBehaviour
{
    [SerializeField] MoneyController _moneyController;
    private TextMeshProUGUI _textMeshPro;

    private void Awake()
    {
        _textMeshPro = GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
        _textMeshPro.text = _moneyController.CurrentMoney.ToString();
    }
}
