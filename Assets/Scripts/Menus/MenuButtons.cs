using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtons : MonoBehaviour
{
    public GameObject HelpWindow;

    public void StartButton()
    {
        SceneManager.LoadScene("MainLevel");
    }

    public void HelpButton()
    {
        HelpWindow.SetActive(true);
    }

    public void CloseHelp()
    {
        HelpWindow.SetActive(false);
    }

    public void QuitButton()
    {
        Application.Quit();
    }
}
