using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndScreenScript : MonoBehaviour
{
    private void Start()
    {
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
    }

    public void RestartClick()
    {
        SceneManager.LoadScene(1);
    }

    public void QuitClick()
    {
        SceneManager.LoadScene(0);
    }
}
