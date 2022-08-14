using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreKeeper2D : MonoBehaviour
{
    int score; 
    public int GetScore()
    {
        return score;
    }
   
    public void ModifyScore(int value)
    {
        score += value;
        Mathf.Clamp(score, 0, int.MaxValue);
        Debug.Log(score);
    }

    public void ResertScore()
    {
        score = 0;
    }
}
