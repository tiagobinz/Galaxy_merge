using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class WinLoseController : MonoBehaviour
{
    [SerializeField] string nextLevel = null;
    [SerializeField] Fade fade = null;

    int deadPlayers = 0;
    
    void Start()
    {
        foreach(Player p in Player.Players)
        {
            p.GetComponent<Health>().onDie += PlayerKilled;
        }
        StartCoroutine(StartRoutine());
    }

    public void BossDefeated()
    {
        StartCoroutine(WinRoutine());
    }

    void PlayerKilled()
    {
        deadPlayers++;
        if (deadPlayers >= Player.Players.Count)
        {
            StartCoroutine(LoseRoutine());
        }
    }

    IEnumerator StartRoutine()
    {
        fade.SetAlpha(1);
        yield return new WaitForSeconds(1);
        fade.FadeOut();
    }

    IEnumerator WinRoutine()
    {
        fade.FadeOut();
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(nextLevel);
    }

    IEnumerator LoseRoutine()
    {
        fade.FadeOut();
        ScoreManager.StoreAndResetCurrentScore();
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene("Menu");
    }
}
