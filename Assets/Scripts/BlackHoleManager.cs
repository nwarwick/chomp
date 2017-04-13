using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackHoleManager: MonoBehaviour {
    public GameObject blackHole; 

	public float maxBlackHole = 10; 

	public float xBound = 80f; 
	public float yBound = 80f;

	public GameObject[] blackHoleList;

	// Use this for initialization
	void Start () {
		if(blackHole == null)
		{
			Debug.Log("No worm prefab found!");
			return;
		}
	}

	// Update is called once per frame
	void Update () {

        blackHoleList = GameObject.FindGameObjectsWithTag ("Heidong");

		if (blackHoleList.Length < maxBlackHole) {
			SpawnBlackHole ();
		}

	}

	// Spawns food at a random location within the specified bounds
	public void SpawnBlackHole(){
		Vector3 spawnLocation = new Vector3(Random.Range(-xBound, xBound), Random.Range(-yBound, yBound), 0);
		Instantiate(blackHole, spawnLocation, Quaternion.identity);
	}
}
