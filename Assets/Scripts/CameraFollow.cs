using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

	public GameObject player;

	void Start () {	}
	
	void FixedUpdate () 
	{
		// Don't follow the player if they are dead
		if(player != null )
			transform.position = new Vector3 (player.transform.position.x, player.transform.position.y, -10f);
	}
}
