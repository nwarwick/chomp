using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpManager : MonoBehaviour
{

    public GameObject powerUp; // Reference to the food object
    public float maxPowerUp = 5; // Max number of powerups to spawn on the map
    public float xBound = 10f; // Bound for the powerup spawn location
    public float yBound = 10f;
    public PowerUp[] powerUpList; // List of food objects on the map

    // Use this for initialization
    void Start()
    {
        if (powerUp == null)
        {
            Debug.Log("No food powerups found!");
            return;
        }
    }

    // Update is called once per frame
    void Update()
    {
        powerUpList = GameObject.FindObjectsOfType<PowerUp>();

        if (powerUpList.Length < maxPowerUp)
        {
            SpawnPowerUp();
        }
    }

	void SpawnPowerUp()
	{
		Vector3 spawnLocation = new Vector3(Random.Range(-xBound, xBound), Random.Range(-yBound, yBound), 0);
		Instantiate(powerUp, spawnLocation, Quaternion.identity);
	}
}
