using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class headMovement : MonoBehaviour {
	// BASIC MOVEMENT VALUES
	public float topSpeed;		// maximum movement speed (if the player's mouse is relatively far away)
	// BOOST VALUES
	public float coolMax;	// this is the "full" value of the boost cooldown
	public float coolReg;	// recovery rate for cooldown
	//public float 
	// INTERNAL BOOST VARIABLES
	float coolCurrent = 0;
	float speedBoost = 1;
	
	void Start () {	}
	
	void FixedUpdate () 
	{
		// rotation code is taken from Homework 2, there might be an easier way to do this?
		var relativeMP = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);
		float mouseDistance2 = relativeMP.y*relativeMP.y + relativeMP.x * relativeMP.x;	// (distance squared)
		
		var relativeMA = Mathf.Atan2(relativeMP.y, relativeMP.x) * Mathf.Rad2Deg;
		transform.rotation = Quaternion.Euler(0, 0, relativeMA-90);
		
		var moveSpeed = speedBoost * topSpeed; // if the worm is currently boosting, the speed is maxed and multiplied
		if (speedBoost <= 1)
		{
			moveSpeed = (mouseDistance2)/(125f*125f);	// otherwise it is derived from mouse distance
			if (moveSpeed > topSpeed)
				moveSpeed = topSpeed;					// and capped to the maximum speed
		}
		gameObject.transform.position += gameObject.transform.up * moveSpeed * Time.deltaTime;
		
		if (coolCurrent > 0)
			coolCurrent -= coolReg*Time.deltaTime;
		if (speedBoost > 1)
			speedBoost -= 2*Time.deltaTime;
		
		if (Input.GetMouseButtonDown (0)) 
		{
			boost();
		}
	}
	
	void boost()
	{
		if (coolCurrent <= 0)
		{
			speedBoost = 6;
			coolCurrent = coolMax;
		}
	}
	
}
