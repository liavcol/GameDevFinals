using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectivesManager : MonoBehaviour
{
    [SerializeField] private GameObject player;    
    [SerializeField] private Text objectiveNameDisplay;
    [SerializeField] private Text objectiveDescriptionDisplay;

    private Objective[] objectives;
    private int curIndex = 0;

    private void Awake() => objectives = GetComponentsInChildren<Objective>(true);

    private void Start()
    {
        objectives[curIndex].OnObjectiveAccomplished += ProgressObjectives;
        DisplayCurrentObjective();
    }

    private void ProgressObjectives()
    {
        objectives[curIndex].OnObjectiveAccomplished -= ProgressObjectives;
        Destroy(objectives[curIndex].gameObject);
        
        curIndex++;
        if (curIndex == objectives.Length)
        {
            GameWon();
            return;
        }
        

        objectives[curIndex].OnObjectiveAccomplished += ProgressObjectives;
        objectives[curIndex].gameObject.SetActive(true);
        DisplayCurrentObjective();
    }

    private void DisplayCurrentObjective()
    {
        if (objectiveNameDisplay != null)
            objectiveNameDisplay.text = $"Objective {curIndex + 1} - {objectives[curIndex].ObjectiveName}";
        if (objectiveDescriptionDisplay != null)
            objectiveDescriptionDisplay.text = objectives[curIndex].ObjectiveDescription;
    }

    private void GameWon()
    {
        Debug.Log("All Missions Accomplished - Game Won!");
    }
}
