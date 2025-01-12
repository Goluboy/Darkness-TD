using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamagedFlash : MonoBehaviour
{
    [SerializeField] private Color[] _colors;
    [SerializeField] private float _time;
    private SpriteRenderer _spriteRenderer;
    private int _currentColorIndex = 0;
    private int _targetColorIndex = 1;
    private float _targetPoint;

    public bool IsColorChanging = false;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();    
    }

    private void Update()
    {
        if (IsColorChanging)
            Transition();
    }

    private void Transition()
    {
        _targetPoint += Time.deltaTime / _time;
        _spriteRenderer.color = Color.Lerp(_colors[_currentColorIndex], _colors[_targetColorIndex], _targetPoint);
        if (_targetPoint >= 1f)
        {
            _targetPoint = 0f;
            _currentColorIndex = _targetColorIndex;
            _targetColorIndex++;
            if (_targetColorIndex == _colors.Length)
            {
                _targetColorIndex = 0;
                IsColorChanging = false;
            }
        }

    }
}