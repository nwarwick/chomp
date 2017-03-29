using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIControls : MonoBehaviour {
	
	// a super-simple AI for collision testing

	public Head head;

	void Start() 
	{
		head = GetComponent<Head> ();
	}
	
	void FixedUpdate () 
	{
		Vector3 testPoint = new Vector3(50f, 0f, 0f);
		head.turnTowards(testPoint);

		head.moveSpeed = head.topSpeed;
		
		// at the moment, te AI doesn't boost
	}
}
