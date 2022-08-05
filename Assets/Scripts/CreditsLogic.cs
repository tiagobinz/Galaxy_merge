using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreditsLogic : MonoBehaviour
{
    const float duration = 30;
    const float minPosition = -1000;
    const float maxPosition = 1100;

    [SerializeField] RectTransform ScrollingCanvas = null;

    public void Play()
    {
        StartCoroutine(CreditsRoutine());
    }

    IEnumerator CreditsRoutine()
    {
        GetComponent<CanvasGroup>().interactable = true;
        GetComponent<CanvasGroup>().blocksRaycasts = true;
        GetComponent<AudioSource>().volume = 0;
        StartCoroutine(FadeInMusic());
        GetComponent<Fade>().FadeIn();
        GetComponent<AudioSource>().Play();

        float alpha = 0;
        while (alpha < 1)
        {
            ScrollingCanvas.anchoredPosition3D = new Vector3
            (
                512,
                Mathf.Lerp(minPosition, maxPosition, alpha),
                0
            );
            alpha += Time.deltaTime / duration;
            yield return null;
        }

        yield return new WaitForSeconds(1);
        GetComponent<Fade>().FadeOut();
        StartCoroutine(FadeOutMusic());
        GetComponent<CanvasGroup>().interactable = false;
        GetComponent<CanvasGroup>().blocksRaycasts = false;
    }

    IEnumerator FadeInMusic()
    {
        while (GetComponent<AudioSource>().volume < 1)
        {
            GetComponent<AudioSource>().volume = GetComponent<AudioSource>().volume + Time.deltaTime;
            yield return null;
        }
    }

    IEnumerator FadeOutMusic()
    {
        while (GetComponent<AudioSource>().volume > 0)
        {
            GetComponent<AudioSource>().volume = GetComponent<AudioSource>().volume - Time.deltaTime;
            yield return null;
        }
    }
}
