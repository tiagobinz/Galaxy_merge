using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;

public static class ScoreManager
{
    static int currentScore = 0;
    const string path = "Assets/Resources/scores.txt";

    public static int GetScore()
    {
        return currentScore;
    }

    public static void SetScore(int score)
    {
        currentScore = score;
    }

    public static void StoreAndResetCurrentScore()
    {
        List<int> scores = GetScores();
        scores.Add(currentScore);
        scores.Sort();
        WriteScores(scores);
        currentScore = 0;
    }

    public static List<int> GetScores()
    {
        StreamReader reader = new StreamReader(path);
        string text = reader.ReadToEnd();
        reader.Close();
        string[] numberTexts = text.Split('\n');
        List<int> result = new List<int>();
        foreach(string s in numberTexts)
        {
            int number = 0;
            if (int.TryParse(s, out number))
            {
                result.Add(number);
            }
        }
        return result;
    }

    static void WriteScores(List<int> scores)
    {
        StreamWriter writer = new StreamWriter(path, false);
        for(int i = 0; i < scores.Count; i++)
        {
            writer.WriteLine(scores[i].ToString());
        }
        writer.Close();
        TextAsset asset = (TextAsset)Resources.Load("scores", typeof(TextAsset));
    }
}
