using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// this started out as a straight copy-paste of FoodManager, but I couldn't get it to recognize AIWorm as a type
// so I tagged the AIWorms and just used an array of GameObjects
// (feel free to change it)

public class WormManager : MonoBehaviour {
	public GameObject wormPref; 
	public float maxWorms = 5; // Max number of worms to spawn on the map
	//public List<GameObject> foodList = new List<GameObject>(); // Food currently on the map
	public float xBound = 80f; // Bound for the worm spawn location
	public float yBound = 80f;
	private GameObject[] wormList;

	// Use this for initialization
	void Start () {
		if(wormPref == null)
		{
			Debug.Log("No AI worm item found!");
			return;
		}
	}
	
	// Update is called once per frame
	void Update () {

		wormList = GameObject.FindGameObjectsWithTag ("AIWorm");

		if (wormList.Length < maxWorms) {
			SpawnWorm ();
		}
		
	}

	// Spawns food at a random location within the specified bounds
	public void SpawnWorm(){
		Vector3 spawnLocation = new Vector3(Random.Range(-xBound, xBound), Random.Range(-yBound, yBound), 0);
		Instantiate(wormPref, spawnLocation, Quaternion.identity);
	}
}
