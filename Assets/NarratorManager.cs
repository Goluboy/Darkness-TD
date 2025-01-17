using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NarratorManager : MonoBehaviour
{
    [SerializeField] private AudioSource _music;

    private AudioSource _narrator;

    private void Awake()
    {
        _narrator = GetComponent<AudioSource>();
    }

    public void PlayNarrator(float time) 
    {
        _narrator.Play();
        Invoke("StartMusic", time);
    }

    private IEnumerator StartMusic()
    {
        _music.Play();
        return null;
    }
}
