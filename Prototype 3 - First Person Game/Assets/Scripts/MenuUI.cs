using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuUI : MonoBehaviour
{
    //On Button Press Play Game
    public void OnPlayButton()
    {
        SceneManager.LoadScene("Game");
    }

    //On Button Press Quit Game
    public void OnQuitButton()
    {
        Application.Quit();
    }
}
