using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Net.Http;
using Newtonsoft.Json;
using TMPro;

public class OptionsMenu : MonoBehaviour
{
    public TextMeshProUGUI coinCountDisplay;

    public TextMeshProUGUI highScoreDisplay;
    // Start is called before the first frame update
    async void Start()
    {
        //Call url to get Player JSON data

        
        using var client = new HttpClient();
        var response = await client.GetAsync(CredentialManager.apiUrl);
        var responseContent = await response.Content.ReadAsStringAsync();
        var ourObject = JsonConvert.DeserializeObject<JsonModel>(responseContent);

        
        coinCountDisplay.text = "Coins Collected: "+ourObject.Item.CoinCount.ToString();
        highScoreDisplay.text = "Top Score: "+ourObject.Item.HighScore.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ReturnToMain(){
        SceneManager.LoadScene("Main Menu");
    }
}
