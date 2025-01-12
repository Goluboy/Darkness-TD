using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeEffect : MonoBehaviour
{
    [SerializeField] float _timeOffset;
    private Image _image;

    private void Awake()
    {
        _image = GetComponent<Image>();
    }

    public void FadeIn(float duration = 1f)
    {
        StartCoroutine(FadeAnimation(duration, 1f, 0f));
    }

    public void FadeOut(float duration = 1f)
    {
        gameObject.SetActive(true);
        StartCoroutine(FadeAnimation(duration, 0f, 1f));
    }

    private IEnumerator FadeAnimation(float duration, float startAlpha, float endAlpha)
    {
        float elapsedTime = 0f;
        Color initialColor = _image.color;

        while (elapsedTime < duration)
        {
            float t = elapsedTime / duration;
            float alpha = Mathf.Lerp(startAlpha, endAlpha, t);
            _image.color = new Color(initialColor.r, initialColor.g, initialColor.b, alpha);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        _image.color = new Color(initialColor.r, initialColor.g, initialColor.b, endAlpha);
    }
}
