using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    public Canvas quitMenu;
    public GameObject start;
    public GameObject exit;

    // Start is called before the first frame update
    void Start()
    {
        quitMenu.enabled = false;
    }

    // Update is called once per frame
    public void ExitPress()
    {
        quitMenu.enabled = true;
        start.SetActive(false);
        exit.SetActive(false);
    }

    public void NoPress()
    {
        quitMenu.enabled = false;
        start.SetActive(true);
        exit.SetActive(true);

    }

    public void StartGame()
    {
        SceneManager.LoadScene(1); // The scene that we want to load (change after)
    }

    public void ExitGame()
    {
        Application.Quit();
        Debug.Log("Quit");
    }
}
