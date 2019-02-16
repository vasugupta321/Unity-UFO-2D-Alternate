using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class KillPlayer : MonoBehaviour {

    public GameObject player;
    public int lives = 3;
    public Text gameOver;
    public Text livesText;

	// Use this for initialization
	void Start () {
        gameOver.text = "";
        SetLiveText();
        
	}
	
	// Update is called once per frame
	void Update () {
        if (lives == 0)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                SceneManager.LoadScene("Main");
                Debug.Log("Game Restarted");
            }
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        lives--;
        SetLiveText(); //update the lives text
        if (lives > 0)
        {
            Invoke("Respawn", 0.1f);
        }
        if (lives == 0){
            //freezes position of player such that player cannot move after death
            player.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePosition;
            gameOver.text = "Game Over! Press Space to restart game";
        }
    }
    void Respawn ()
    {
        player.transform.position = new Vector2(0, 0); // respawns player
    }
    void SetLiveText()
    {
        livesText.text = "Lives: " + lives.ToString();
    }
}
