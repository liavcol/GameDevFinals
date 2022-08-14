using System;
using System.Collections.Generic;
using UnityEngine;

public class ScoreKeeper2D : MonoBehaviour
{
    int score;
    public Action<int> OnScoreChange;

    public int GetScore()
    {
        return score;
    }

    public void ModifyScore(int value)
    {
        score += value;
        Mathf.Clamp(score, 0, int.MaxValue);
        OnScoreChange?.Invoke(score);
        Debug.Log(score);
    }

    public void ResertScore()
    {
        score = 0;
    }
}
