using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class SceneController : MonoBehaviour
{
    public GameObject Finish;

    private void Start()
    {
        if (Finish != null)
        {
            if (Finish.GetComponent<Finish>() != null)
            {
                Finish.GetComponent<Finish>().PlayerFinish += OnPlayerFinished;
            }
        }
    }

    private void Update()
    {
        if(Input.GetKey(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    private void OnPlayerFinished()
    {
        if (SceneManager.sceneCountInBuildSettings <= SceneManager.GetActiveScene().buildIndex + 1)
        {
            SceneManager.LoadScene(0);
            return;
        }

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        SaveSystem.SaveGame(new GameSettings(SceneManager.GetActiveScene().buildIndex + 1));

        Finish.GetComponent<Finish>().PlayerFinish -= OnPlayerFinished;
    }

    public void ToMainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
