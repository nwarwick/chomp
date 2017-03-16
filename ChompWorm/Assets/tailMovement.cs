using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tailMovement : MonoBehaviour {

	public GameObject leader;
	public float stickDistance;
	public float leaderDistance2;

	void Start () {	}
	
	void FixedUpdate () {
		var leaderspot = leader.transform.position - transform.position;
		//float leaderDistance2 = leaderspot.y*leaderspot.y + leaderspot.x * leaderspot.x;	// (distance squared)
		leaderDistance2 = leaderspot.y*leaderspot.y + leaderspot.x * leaderspot.x;	// (distance squared)
		
		var leaderangle = Mathf.Atan2(leaderspot.y, leaderspot.x) * Mathf.Rad2Deg;
		transform.rotation = Quaternion.Euler(0, 0, leaderangle-90);
		
		if (leaderDistance2 > stickDistance*stickDistance)
		{
			gameObject.transform.position += gameObject.transform.up * 3 * Time.deltaTime;
		}
		
	}
}
