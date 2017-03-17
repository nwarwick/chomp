using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class headMovement : MonoBehaviour 
{
	// BASIC MOVEMENT VALUES
	public float topSpeed;		// maximum movement speed (when not boosting)
	// BOOST VALUES
	public float coolMax;	// this is the "full" value of the boost cooldown
	public float coolReg;	// recovery rate for cooldown
	// INTERNAL MOVEMENT VARIABLES
	public float moveSpeed = 0;  // (this is only "public" so playerControls and AI can get at it)
	// INTERNAL BOOST VARIABLES
	float coolCurrent = 0;
	float speedBoost = 1;
	
	void Start () {	}
	
	void FixedUpdate () 
	{
		if (moveSpeed > topSpeed)
			moveSpeed = topSpeed;
		gameObject.transform.position += gameObject.transform.up * moveSpeed * Time.deltaTime;
		
/*		var moveSpeed = speedBoost * topSpeed; // if the worm is currently boosting, the speed is maxed and multiplied
		if (speedBoost <= 1)
		{
			moveSpeed = (mouseDistance2)/(125f*125f);	// otherwise it is derived from mouse distance
			if (moveSpeed > topSpeed)
				moveSpeed = topSpeed;					// and capped to the maximum speed
		}
		gameObject.transform.position += gameObject.transform.up * moveSpeed * Time.deltaTime;
		*/
		if (coolCurrent > 0)
			coolCurrent -= coolReg*Time.deltaTime;
		if (speedBoost > 1)
			speedBoost -= 2*Time.deltaTime;
		
		
	}
	
	public void turnTowards(Vector3 point)
	{
		var relativeMA = Mathf.Atan2(point.y, point.x) * Mathf.Rad2Deg;
		transform.rotation = Quaternion.Euler(0, 0, relativeMA-90);
	}
	
	public void boost()
	{
		if (coolCurrent <= 0)
		{
			//speedBoost = 6; // HOW DOES BOOST ACTUALLY WORK
			coolCurrent = coolMax;
		}
	}
	
}
