using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    private Vector2 desiredDirection;
    public float increment;
    public float speed;
    private float boundary = 3.7f;

    public TextMeshProUGUI healthDisplay;

    public TextMeshProUGUI coinDisplay;
    public int health;

    public int coinCount;
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
}
