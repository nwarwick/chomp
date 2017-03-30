using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodManager : MonoBehaviour {
	public GameObject foodItem; // Reference to the food object
	public float maxFood = 5; // Max number of food to spawn on the map
	//public List<GameObject> foodList = new List<GameObject>(); // Food currently on the map
	public float xBound = 10f; // Bound for the food spawn location
	public float yBound = 10f;
	public Food[] foodList; // List of food objects on the map

	// Use this for initialization
	void Start () {
		if(foodItem == null)
		{
			Debug.Log("No food item found!");
			return;
		}
	}
	
	// Update is called once per frame
	void Update () {

		foodList = GameObject.FindObjectsOfType<Food> ();

		if (foodList.Length < maxFood) {
			SpawnFood ();
		}
		
	}

	// Spawns food at a random location within the specified bounds
	public void SpawnFood(){
		Vector3 spawnLocation = new Vector3(Random.Range(-xBound, xBound), Random.Range(-yBound, yBound), 0);
		Instantiate(foodItem, spawnLocation, Quaternion.identity);
	}
}
