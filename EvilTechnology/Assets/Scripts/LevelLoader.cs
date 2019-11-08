using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public void StartButton()
    {
        FindObjectOfType<GameSession>().ResetScore();
        SceneManager.LoadScene(1);
    }

    public void QuitButton()
    {
        Application.Quit();
    }

    public void GameOver()
    {
        SceneManager.LoadScene(2);
    }

}
