using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(CanvasGroup))]
public class Fade : MonoBehaviour
{
    public void FadeIn()
    {
        StartCoroutine(FadeInRoutine());
    }

    public void FadeOut()
    {
        StartCoroutine(FadeOutRoutine());
    }

    public void SetAlpha(float inAlpha)
    {
        GetComponent<CanvasGroup>().alpha = inAlpha;
    }

    IEnumerator FadeInRoutine()
    {
        CanvasGroup cg = GetComponent<CanvasGroup>();
        cg.blocksRaycasts = true;
        while (cg && cg.alpha < 1)
        {
            cg.alpha += Time.deltaTime * 4;
            yield return null;
        }
        cg.interactable = true;
    }

    IEnumerator FadeOutRoutine()
    {
        CanvasGroup cg = GetComponent<CanvasGroup>();
        cg.interactable = false;
        while (cg && cg.alpha > 0)
        {
            cg.alpha -= Time.deltaTime * 2;
            yield return null;
        }
        cg.blocksRaycasts = false;
    }
}
