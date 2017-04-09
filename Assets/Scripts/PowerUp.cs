using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour {

	public AudioManager am;

	// Use this for initialization
	void Start () {
		am = GameObject.Find("AudioManager").GetComponent<AudioManager>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		// Check if we hit a Player/AI head
		if(gameObject.tag == "UltimatePowerUp" && other.gameObject.tag == "Head")
		{
			Debug.Log("POWERING UP");
			EnableUltimate(other.gameObject);
		}
	}


	void EnableUltimate(GameObject receiver)
	{
		// TODO
		Destroy(gameObject);
		am.PlaySound("PowerUp");
	}
}
