using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Net.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using TMPro;
public class MainMenu : MonoBehaviour
{
    public void Start(){

    }
     //Load the game upon clicking play
    public void PlayGame() {
        SceneManager.LoadScene("Game");
    }
    //Allow users to exit the game from main menu
    public void ExitGame() {
        //Quits in real build
        Application.Quit();
        //Added code to show quit in unity editor for showcasing gameplay
        UnityEditor.EditorApplication.isPlaying = false;
    }

    public void EnterOptions() {
        SceneManager.LoadScene("Options");
    }
}


public partial class JsonModel{
    [JsonProperty("Item")]
    public Item Item {get; set;}
}
public partial class Item{
    [JsonProperty("id")]
    public int id {get; set;}

    [JsonProperty("CoinCount")]
    public int CoinCount{get; set;}

    [JsonProperty("HighScore")]
    public int HighScore{get; set;}
}
