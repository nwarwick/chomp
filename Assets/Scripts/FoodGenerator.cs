using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodGenerator : MonoBehaviour {
	public GameObject foodItem; // Reference to the food object
	public float foodCount = 5; // Max number of food to spawn on the map
	public List<GameObject> foodList = new List<GameObject>(); // Food currently on the map
	public float xBound = 5f; // Bound for the food spawn location
	public float yBound = 5f;

	// Use this for initialization
	void Start () {
		if(foodItem == null)
		{
			Debug.Log("No food item found!");
			return;
		}

		for (int i = 0; i < foodCount; i++)
		{
			SpawnFood();
		}
	}
	
	// Update is called once per frame
	void Update () {
		// If total food on map is less than foodCount, spawn food
		if(foodList.Count < foodCount)
		{
			SpawnFood();
		}
		
	}

	// Spawns food at a random location within the specified bounds
	public void SpawnFood(){
		Vector3 spawnLocation = new Vector3(Random.Range(-xBound, xBound), Random.Range(-yBound, yBound), 0);
		Instantiate(foodItem, spawnLocation, Quaternion.identity);
		foodList.Add(foodItem);
	}
}
