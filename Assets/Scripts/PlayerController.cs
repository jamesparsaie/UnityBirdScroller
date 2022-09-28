using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    private Vector2 desiredDirection;
    public float increment;
    public float speed;
    private float boundary = 3.7f;

    public int health;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(health <= 0){
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        transform.position = Vector2.MoveTowards(transform.position, desiredDirection, speed*Time.deltaTime);
        if (Input.GetKeyDown(KeyCode.UpArrow) && transform.position.y < boundary) {
            desiredDirection = new Vector2(transform.position.x, transform.position.y + increment);
        }  else if(Input.GetKeyDown(KeyCode.DownArrow) && transform.position.y > -boundary) {
            desiredDirection = new Vector2(transform.position.x, transform.position.y - increment);
        }
    }
}
