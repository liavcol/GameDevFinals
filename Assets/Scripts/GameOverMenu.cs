using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverMenu : MonoBehaviour
{
    [SerializeField]
    private Text messageText;
    [SerializeField]
    private string winningMessage;
    [SerializeField]
    private string losingMessage;
    [SerializeField]
    private new Camera camera;

    public static void ActivateGameOverMenu(GameOverMenu gameOverMenu, bool playerWon)
    {
        foreach (GameObject go in GameObject.FindGameObjectsWithTag("HUD"))
            go.SetActive(false);
        foreach (GameObject go in GameObject.FindGameObjectsWithTag("Enemy"))
            go.SetActive(false);

        gameOverMenu.gameObject.SetActive(true);
        gameOverMenu.PlayerWon = playerWon;
        if (gameOverMenu.camera)
            gameOverMenu.camera.gameObject.SetActive(true);
    }

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

    public void Awake() => Cursor.lockState = CursorLockMode.None;

    public void PlayGame(int sceneIndex) => SceneManager.LoadScene(sceneIndex);

    public void PlayAgain() => SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    public void Quit() => SceneManager.LoadScene(0);

    public void ExitGame() => Application.Quit();
}