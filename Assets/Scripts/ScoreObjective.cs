using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreObjective : Objective
{
    [SerializeField]
    private ScoreKeeper2D scoreKeeper;
    [SerializeField]
    private int requiredScore;

    private void Start() => scoreKeeper.OnScoreChange += CheckScore;

    private void CheckScore(int score)
    {
        if (score >= requiredScore)
            ObjectiveAccomplished();
    }

    protected override void ObjectiveAccomplished() => OnObjectiveAccomplished?.Invoke();
}
