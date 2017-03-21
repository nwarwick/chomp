using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIControls : MonoBehaviour {
	
	// a super-simple AI for collision testing

	public HeadMovement headMovement;

	void Start() 
	{
		headMovement = GetComponent<HeadMovement> ();
	}
	
	void FixedUpdate () 
	{
		Vector3 testPoint = new Vector3(50f, 0f, 0f);
		headMovement.turnTowards(testPoint);

		headMovement.moveSpeed = headMovement.topSpeed;
		
		// at the moment, te AI doesn't boost
	}
}
