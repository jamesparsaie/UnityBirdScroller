using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public int score;
    public TextMeshProUGUI scoreBoard;
    public float timeTracker = 0;
    public static int scoreTracker = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timeTracker+=Time.deltaTime;
        if(timeTracker >= 1){
            timeTracker = 0;
            scoreTracker++;
            scoreBoard.text = "Score: "+scoreTracker.ToString();
        }
    }
}
