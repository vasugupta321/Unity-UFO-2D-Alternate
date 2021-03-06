using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; //allows for management of scenes

public class PlayerController : MonoBehaviour {

	public float speed;
	public Text countText;
    public Text winText;

	private Rigidbody2D rb2d; //Storing a reference to the RigidBody2D component required for 2D physics
    Rigidbody2D player;
	private int count; // count for objects picked up



	void Start()
	{
		//Retrieve and store reference to Rigidbody2D component so that we are able to access it
		rb2d = GetComponent<Rigidbody2D> ();

		count = 0;
		SetCountText ();
		winText.text = ""; // this is equivalent to winText.text = string.Empty
        player = GetComponent<Rigidbody2D>();
	}
	
	void FixedUpdate()
	{
		// THE BELOW GRABS INPUT FROM THE PLAYER THROUGH THE KEYBOARD
		float moveHorizontal = Input.GetAxis ("Horizontal"); //moveHoziontal records input from horziontal axis
		float moveVertical = Input.GetAxis ("Vertical"); //moveVertical records input from vertical axis controlled by keys on keyboard

		rb2d.GetComponent<Rigidbody2D> ().transform.Rotate (0, 0, 2f);

		//To get the 2 float values in vector2 for addForce, we create new variable which is equal to new vector2 made up of x and y values)
		//where the x and y values determine direction of force we add to UFO so x value is moveHorizontal and y value is moveVertical
		Vector2 movement = new Vector2 (moveHorizontal, moveVertical);

		//the above variable is now used below
		//we multiply the public variable speed to be able to control the movement of the player
		//because speed is public we can change the value in the editor
		rb2d.AddForce (movement * speed);

        if (count >= 12)
        {
            winText.text = "You Win! Press Space to restart";
            player.constraints = RigidbodyConstraints2D.FreezePosition;
            if (Input.GetKey(KeyCode.Space))
            {
                Debug.Log("Key has been pressed");
                SceneManager.LoadScene("Main");
            }
        }
    }
		
	void OnTriggerEnter2D(Collider2D other) // reference to collider we touch
	{
		
		if (other.gameObject.CompareTag("PickUp")) //test if other's tag is same as "PickUp"
		{
			other.gameObject.SetActive(false); // we take other gameObject and setActive false which deactivates it
			count++;
			SetCountText ();
		}
	}

	void SetCountText()
	{
		countText.text = "Count: " + count.ToString ();
	}
}
