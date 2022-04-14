using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIButtonScript : MonoBehaviour
{
    public void QuitButtonPressed()
    {
        Application.Quit();
    }

    public void MainMenuButtonPressed()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void PlayButtonPressed()
    {
        SceneManager.LoadScene("SampleScene");
    }
    
}
