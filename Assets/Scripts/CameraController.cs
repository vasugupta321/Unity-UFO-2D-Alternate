 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	public GameObject player;

	//offset is private cause we can set its value in the script
	//for offset value we tale current transform postion of camera and
	//subtract the transform position of player and we do this in start ()
	private Vector3 offset;

	// Use this for initialization
	void Start () 
	{
		//transfor respresents transform of the game object that script is attached too
		offset = transform.position - player.transform.position;
	}
	
	// LateUpdate is called once per frame
	// we will set the transform position of the camera to the players transform position plus the offset
	// LateUpdate guranteed to run after all items proccessed in update ()
	void LateUpdate () {
		transform.position = player.transform.position + offset;
	}
}
