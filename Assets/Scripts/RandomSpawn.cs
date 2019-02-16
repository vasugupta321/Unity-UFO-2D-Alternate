using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawn : MonoBehaviour {

    public GameObject pickUpToClone;
    private int count = 0;

	// Use this for initialization
	void Start ()
    {
        //At the start of the game, Pickup is cloned at a speed of 0.1f
        InvokeRepeating("CloneItem", 0.5f, 0.5f);
    }

    void CloneItem()
    {
        GameObject clone = Instantiate(pickUpToClone); //clone for the Pickup game object
        clone.SetActive(true); //setActive to true to activate/spawn Pickup game object

        //random ranges for every cloned pickup game object
        clone.transform.position = new Vector2(Random.Range (-11f, 11f), Random.Range(-11f, 11f));
        count++;

        if (count == 12)
        {
            CancelInvoke(); //stops spawning of the pickup game objects
        }
    }

}
