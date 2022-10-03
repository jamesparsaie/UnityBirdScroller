using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
     //Load the game upon clicking play
    public void PlayGame() {
        SceneManager.LoadScene("Game");
    }
    //Allow users to exit the game from main menu
    public void ExitGame() {
        Application.Quit();
    }
}
