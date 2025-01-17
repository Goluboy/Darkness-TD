using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetActiveByButton : MonoBehaviour
{
    private float _timeRemaining;
    private bool _endState = true;

    public void SetActive()
    {
        gameObject.SetActive(!gameObject.activeSelf);
    }

    public void SetTimerActive(float timeRemaining)
    {
        _timeRemaining = timeRemaining;
        _endState = false;
        gameObject.SetActive(true);
    }

    public void SetTimerInative(float timeRemaining)
    {
        _timeRemaining = timeRemaining;
        _endState = true;
        gameObject.SetActive(false);
    }

    private void Update()
    {
        if (_timeRemaining > 0 && gameObject.activeSelf != _endState)
        {
            if (gameObject.name == "Level Selection")
                Debug.Log(_timeRemaining);
            _timeRemaining -= Time.deltaTime;
        }
        else if (gameObject.activeSelf != _endState)
        {
            gameObject.SetActive(_endState);
        }
    }
}
