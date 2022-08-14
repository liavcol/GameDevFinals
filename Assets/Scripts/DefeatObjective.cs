using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefeatObjective : Objective
{
    [SerializeField]
    private Health[] targets;

    private int numDefeated;

    private void Start()
    {
        foreach(Health h in targets)
            h.OnDie += CountDefeat;
        
    }

    private void CountDefeat()
    {
        numDefeated++;
        if (numDefeated == targets.Length)
            ObjectiveAccomplished();
    }

    protected override void ObjectiveAccomplished() => OnObjectiveAccomplished?.Invoke();
}
