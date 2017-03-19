using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TailMovement : MonoBehaviour {

	public GameObject leader;
	public float stickDistance;
	
	void Start () {	}
	
	void FixedUpdate () {
		var leaderspot = leader.transform.position - transform.position;
		float leaderDistance2 = leaderspot.y*leaderspot.y + leaderspot.x * leaderspot.x;	// (distance squared)
		
		var leaderangle = Mathf.Atan2(leaderspot.y, leaderspot.x) * Mathf.Rad2Deg;
		transform.rotation = Quaternion.Euler(0, 0, leaderangle-90);
		
		var moveSpeed = (leaderDistance2*2.0f)/(stickDistance*stickDistance);
		gameObject.transform.position += gameObject.transform.up * moveSpeed * Time.deltaTime;
		
	}
}
