using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public void Continue()
    {
        Application.LoadLevel(Application.loadedLevel);
    }
    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
