using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GatewayManager : MonoBehaviour {
	public GameObject Gateway; 

	public float maxGateway = 10; 

	public float xBound = 50f; 
	public float yBound = 50f;

	public GameObject[] GatewayList;

	// Use this for initialization
	void Start () {
		if(Gateway == null)
		{
			Debug.Log("No Gateway found!");
			return;
		}
	}

	// Update is called once per frame
	void Update () {

        GatewayList = GameObject.FindGameObjectsWithTag ("Chuansong");

		if (GatewayList.Length < maxGateway) {
            SpawnGateway();
		}

	}

	// Spawns food at a random location within the specified bounds
	public void SpawnGateway(){
		Vector3 spawnLocation = new Vector3(Random.Range(-xBound, xBound), Random.Range(-yBound, yBound), 0);
		Instantiate(Gateway, spawnLocation, Quaternion.identity);
	}
}
