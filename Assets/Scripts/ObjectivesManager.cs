using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ObjectivesManager : MonoBehaviour
{
    [SerializeField]
    private bool loadNextScene;
    [SerializeField]
    private Health player;    
    [SerializeField]
    private Text objectiveNameDisplay;
    [SerializeField]
    private Text objectiveDescriptionDisplay;
    [SerializeField]
    private GameOverMenu gameOverMenu;

    private Objective[] objectives;
    private int curIndex = 0;

    private void Awake() => objectives = GetComponentsInChildren<Objective>(true);

    private void Start()
    {
        player.OnDie += GameLost;
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
        if(loadNextScene)
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

        else if (gameOverMenu)
            GameOverMenu.ActivateGameOverMenu(gameOverMenu, true);
    }

    private void GameLost()
    {
        Debug.Log("Player Dead - Game Lost!");
        if (gameOverMenu)
            GameOverMenu.ActivateGameOverMenu(gameOverMenu, false);
    }
}
