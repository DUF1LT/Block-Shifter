using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public Button ContinueButton;

    public void Awake()
    {
        if (ContinueButton != null)
        {
            ContinueButton.interactable = SaveSystem.IsSaveExists();
        }
    }
    public void OnNewGame()
    {
        SaveSystem.SaveGame(new GameSettings(1));
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void OnContinue()
    {
        int level = SaveSystem.LoadGame().Level;
        if (SceneManager.sceneCountInBuildSettings >= level)
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + level);
        else
            throw new System.Exception("Unaccesible level");
    }

    public void OnExit()
    {
        Application.Quit();
    }
}
