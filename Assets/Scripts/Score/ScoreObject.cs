using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[RequireComponent(typeof(TextMeshProUGUI))]
public class ScoreObject : MonoBehaviour
{
    public static ScoreObject Instance;

    const float animationDuration = 0.25f;

    int score = 0;
    float currentAnimationTime = 0;
    Coroutine currentAnimation = null;
    TextMeshProUGUI tmp;

    void Start()
    {
        Instance = this;
        tmp = GetComponent<TextMeshProUGUI>();
        score = ScoreManager.GetScore();
        tmp.text = "Score " + score;
    }

    public void AddScore(int amount)
    {
        score += amount;
        ScoreManager.SetScore(score);
        currentAnimationTime = 0;
        tmp.text = "Score " + score;
        if (currentAnimation == null)
        {
            currentAnimation = StartCoroutine(DoAnimation(tmp));
        }
    }

    IEnumerator DoAnimation(TextMeshProUGUI tmp)
    {
        while (currentAnimationTime < animationDuration)
        {
            float alpha = currentAnimationTime / animationDuration;

            // Scale
            float scale = Mathf.Lerp(1.1f, 1, alpha);
            GetComponent<RectTransform>().localScale = new Vector3(scale, scale, scale);

            // Color
            tmp.color = new Color(alpha, 1, 1);

            currentAnimationTime += Time.deltaTime;
            yield return null;
        }

        GetComponent<RectTransform>().localScale = Vector3.one;
        currentAnimation = null;
    }
}
