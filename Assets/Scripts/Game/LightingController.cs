using System.Collections;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class LightingController : MonoBehaviour
{
    [SerializeField] private Light2D _globalLight;
    [SerializeField] private float _offsetInSeconds;
    [SerializeField] private float _duration;
    [SerializeField] private float _durationBetween;
    [SerializeField] private float _firstIntenity;
    [SerializeField] private float _secondIntenity;

    private float _timeLast = 0f;
    private bool _isFirstLighting = true;

    private void Awake()
    {
        StartCoroutine(RunFirstLighting());
    }

    private void OnDisable()
    {
        StopAllCoroutines();
    }

    private void Update()
    {
        if (_timeLast > 0)
        {
            _timeLast -= Time.deltaTime;
            if (_isFirstLighting)
                _globalLight.intensity = _firstIntenity * _timeLast / _duration;
            else
                _globalLight.intensity = _secondIntenity * _timeLast / _duration;
        }
        else
        {
            _globalLight.intensity = 0;
        }
    }
    private IEnumerator RunFirstLighting()
    {
        while (true)
        {
            ThrowLighting(_firstIntenity);
            _isFirstLighting = true;
            yield return new WaitForSeconds(Random.Range(_durationBetween*0.8f, _durationBetween * 1.2f));
            ThrowLighting(_secondIntenity);
            _isFirstLighting = false;
            yield return new WaitForSeconds(Random.Range(_offsetInSeconds * 0.8f, _offsetInSeconds * 1.2f));
        }
    }

    private void ThrowLighting(float intesnity)
    {
        _timeLast = _duration;
        _globalLight.intensity = intesnity;
    }
}
