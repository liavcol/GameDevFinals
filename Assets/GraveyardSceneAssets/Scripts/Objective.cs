using UnityEngine;
using UnityEngine.UI;

public class Objective : MonoBehaviour
{
    [SerializeField] private int objectiveNumber;
    [SerializeField] private string objectiveName;
    [TextArea] [SerializeField] private string objectiveDescription;

    [SerializeField] private DoorScript door;

    [SerializeField] private Objective nextObjective;

    [SerializeField] private Text objectiveNameDisplay;
    [SerializeField] private Text objectiveDescriptionDisplay;

    // Start is called before the first frame update
    void Start()
    {
        door.OnDoorOpened += ObjectiveAccomplished;
        if (objectiveNameDisplay != null)
            objectiveNameDisplay.text = $"Objective {objectiveNumber} - {objectiveName}";
        if (objectiveDescriptionDisplay != null)
            objectiveDescriptionDisplay.text = objectiveDescription;
    }

    private void ObjectiveAccomplished()
    {
        door.OnDoorOpened -= ObjectiveAccomplished;
        if (objectiveNameDisplay != null)
            objectiveNameDisplay.text = "Objective Accomplished.";
        if (objectiveDescriptionDisplay != null)
            objectiveDescriptionDisplay.text = "";

        if (nextObjective != null)
            nextObjective.enabled = true;
        else
            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerScript>().PlayerWon();
        
        Destroy(gameObject);
    }
}
