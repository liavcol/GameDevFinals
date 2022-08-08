using System;
using UnityEngine;
using UnityEngine.UI;

public abstract class Objective : MonoBehaviour
{
    [SerializeField] private string objectiveName;
    [TextArea][SerializeField] private string objectiveDescription;

    public string ObjectiveName { get { return objectiveName; } }
    public string ObjectiveDescription { get { return objectiveDescription; } }

    public Action OnObjectiveAccomplished;

    //protected abstract void StartObjective();
    protected abstract void ObjectiveAccomplished();
}