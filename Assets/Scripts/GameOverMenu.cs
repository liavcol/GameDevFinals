using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverMenu : MonoBehaviour
{
    [SerializeField] private Text messageText;
    [SerializeField] private string winningMessage;
    [SerializeField] private string losingMessage;

    private bool playerWon = true;

    public bool PlayerWon
    {
        set 
        { 
            playerWon = value;
            if (playerWon)
                messageText.text = winningMessage;
            else
                messageText.text = losingMessage;
        }
    }

    public void Awake()
    {
        Cursor.lockState = CursorLockMode.None;
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene(0);
    }

    public void Quit()
    {
        Application.Quit();
    }
}