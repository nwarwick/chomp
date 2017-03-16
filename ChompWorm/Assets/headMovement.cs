using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class headMovement : MonoBehaviour {
	public float topSpeed;


	void Start () {	}
	
	void FixedUpdate () {
		// rotation code is taken from Homework 2, there might be an easier way to do this?
		var relativeMP = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);
		float mouseDistance2 = relativeMP.y*relativeMP.y + relativeMP.x * relativeMP.x;	// (distance squared)
		
		var relativeMA = Mathf.Atan2(relativeMP.y, relativeMP.x) * Mathf.Rad2Deg;
		transform.rotation = Quaternion.Euler(0, 0, relativeMA-90);
		
		var moveSpeed = (mouseDistance2)/(125f*125f);	// this is so the worm moves slower/faster if the mous is closer/further
		if (moveSpeed > topSpeed)
			moveSpeed = topSpeed;
		gameObject.transform.position += gameObject.transform.up * moveSpeed * Time.deltaTime;
	}
}
