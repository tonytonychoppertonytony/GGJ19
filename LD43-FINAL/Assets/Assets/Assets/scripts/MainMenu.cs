using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

	public void PlayGame()
    {
        // Upon click of 'PLAY' button
        // Load next scene in the queue of build index (file>buildsettings)
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +1);
    }

    public void QuitGame()
    {
        // Quits the game when the application is running (this wont work inside the unity editor so we Debug to test its working)
        Debug.Log("Quit debug successful");
        Application.Quit();
    }

    public void GoToMenu()
    {
        // unfinished

    }

}
