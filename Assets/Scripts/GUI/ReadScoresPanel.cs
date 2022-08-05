using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ReadScoresPanel : MonoBehaviour
{
    TextMeshProUGUI First;
    TextMeshProUGUI Second;
    TextMeshProUGUI Third;

    void Start()
    {
        First =  transform.Find("1st score").GetComponent<TextMeshProUGUI>();
        Second = transform.Find("2nd score").GetComponent<TextMeshProUGUI>();
        Third =  transform.Find("3rd score").GetComponent<TextMeshProUGUI>();

        List<int> scores = ScoreManager.GetScores();

        First.text  = scores.Count >= 1 ? scores[scores.Count - 1].ToString() : "0";
        Second.text = scores.Count >= 2 ? scores[scores.Count - 2].ToString() : "0";
        Third.text  = scores.Count >= 3 ? scores[scores.Count - 3].ToString() : "0";
    }
}
