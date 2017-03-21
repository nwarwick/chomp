using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TailMovement : MonoBehaviour {

	public GameObject leader;
	public float stickDistance;
	
	public bool dead = false;
	public Vector3 deadAngle = new Vector3(0f, 0f, 0f);
	
	void Start () {	}
	
	void FixedUpdate () {
		if (dead)
		{	// if dead
			gameObject.transform.position += deadAngle * Time.deltaTime; // slide in a randomly selected (by WormDie.cs) direction
			transform.Rotate(Vector3.forward * Time.deltaTime * 90f);	// rotate
			transform.localScale += new Vector3(-0.003f, -0.003f, 0);
			
		}
		else
		{	// otherwise, follow the leader
			var leaderspot = leader.transform.position - transform.position;
			float leaderDistance2 = leaderspot.y*leaderspot.y + leaderspot.x * leaderspot.x;	// (distance squared)
		
			var leaderangle = Mathf.Atan2(leaderspot.y, leaderspot.x) * Mathf.Rad2Deg;
			transform.rotation = Quaternion.Euler(0, 0, leaderangle-90);
		
			var moveSpeed = (leaderDistance2*2.0f)/(stickDistance*stickDistance);
			gameObject.transform.position += gameObject.transform.up * moveSpeed * Time.deltaTime;
		}
		
	}
}
