using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider other)
	{
		Debug.Log("POWERING UP");
		if(gameObject.tag == "UltimatePowerUp")
		{
			EnableUltimate(other.gameObject);
		}
	}


	void EnableUltimate(GameObject receiver)
	{
		// TODO
	}
}
