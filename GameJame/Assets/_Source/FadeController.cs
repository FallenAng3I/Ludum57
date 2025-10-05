using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class FadeController : MonoBehaviour
{
    [Header("Settings")]
    public Image fadeImage;
    [Range(0.5f, 5f)] public float fadeDuration = 1.5f;

    private void Awake()
    {
        if (fadeImage == null)
            fadeImage = GetComponent<Image>();
    }

    public IEnumerator FadeOut()
    {
        float time = 0f;
        Color color = fadeImage.color;

        while (time < fadeDuration)
        {
            float alpha = Mathf.Lerp(0f, 1f, time / fadeDuration);
            fadeImage.color = new Color(color.r, color.g, color.b, alpha);
            time += Time.deltaTime;
            yield return null;
        }

        fadeImage.color = new Color(color.r, color.g, color.b, 1f);
    }

    public IEnumerator FadeIn()
    {
        float time = 0f;
        Color color = fadeImage.color;

        while (time < fadeDuration)
        {
            float alpha = Mathf.Lerp(1f, 0f, time / fadeDuration);
            fadeImage.color = new Color(color.r, color.g, color.b, alpha);
            time += Time.deltaTime;
            yield return null;
        }

        fadeImage.color = new Color(color.r, color.g, color.b, 0f);
    }
}