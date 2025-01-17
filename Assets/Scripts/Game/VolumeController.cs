using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class VolumeController : MonoBehaviour
{
    [SerializeField] AudioMixer _mixer;

    [SerializeField] private float _multiplier = 20f;

    public void HandleSliderChange(float value)
    {
        var volumeValue = Mathf.Log10(value + 1e-5f) * _multiplier;
        _mixer.SetFloat("Volume", volumeValue);
    }
}
