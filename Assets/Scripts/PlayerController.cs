using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System.Net.Http;
using Newtonsoft.Json;

public class PlayerController : MonoBehaviour
{
    private Vector2 desiredDirection;
    public float increment;
    public float speed;
    private float boundary = 3.7f;

    private static readonly HttpClient client = new HttpClient();
    public TextMeshProUGUI healthDisplay;

    public TextMeshProUGUI coinDisplay;
    public int health;

    public int coinCount;

    private Dictionary<string, string> values = new Dictionary<string, string>();
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Track health and score display
        coinDisplay.text = "Coins: "+coinCount.ToString();
        healthDisplay.text = "Health: "+health.ToString();

        //Manage reset if health below 0
        if(health <= 0){
            //Update data for player
            UpdatePlayerData();
            //Relaod the main menu on death
            SceneManager.LoadScene("Main Menu");
        }
        
        if (Input.GetKeyDown(KeyCode.UpArrow) && transform.position.y < boundary) {
            desiredDirection = new Vector2(transform.position.x, transform.position.y + increment);
            transform.position = desiredDirection;
        }  else if(Input.GetKeyDown(KeyCode.DownArrow) && transform.position.y > -boundary) {
            desiredDirection = new Vector2(transform.position.x, transform.position.y - increment);
            transform.position = desiredDirection;
        }
    }

    //Method to update our databse with new information from player session
    async void UpdatePlayerData(){
        values.Add("id", 0.ToString());
        values.Add("CoinCount", coinCount.ToString());
        values.Add("HighScore", ScoreManager.scoreTracker.ToString());
        var jsonData = JsonConvert.SerializeObject(values);
        var contentData = new StringContent(jsonData, System.Text.Encoding.UTF8, "application/json");
        await client.PutAsync(CredentialManager.apiPutUrl, contentData);
    }
}
