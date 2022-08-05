using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneManagerComponent : MonoBehaviour
{
    [SerializeField] CanvasGroup fadeGroup = null;

    public void LoadScene(string scene)
    {
        StartCoroutine(LoadSceneAfterDelay(scene));
    }

    IEnumerator LoadSceneAfterDelay(string scene)
    {
        while(fadeGroup && fadeGroup.alpha < 1)
        {
            fadeGroup.alpha += Time.deltaTime / 2;
            yield return null;
        }

        SceneManager.LoadScene(scene);
    }
}
