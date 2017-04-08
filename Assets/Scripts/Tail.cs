using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tail : MonoBehaviour {

	public GameObject leader;
	public float stickDistance;
	
	public bool dead = false;
	public Vector3 deadAngle = new Vector3(0f, 0f, 0f);
	
	public float moveSpeed = 0.0f;
	
	void Start () 
	{
		Physics2D.IgnoreCollision(leader.GetComponent<CircleCollider2D>(), GetComponent<CircleCollider2D>()); // Ignore collisions with leading object
	}
	
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
			//float leaderDistance2 = leaderspot.y*leaderspot.y + leaderspot.x * leaderspot.x;	// (distance squared)
			//float modifiedDistance2 = leaderDistance2 - (stickDistance*stickDistance);			// (distance squared -stickdistance squared)
		
			var leaderangle = Mathf.Atan2(leaderspot.y, leaderspot.x) * Mathf.Rad2Deg;
			transform.rotation = Quaternion.Euler(0, 0, leaderangle-90);
			
			gameObject.transform.position += gameObject.transform.up * (leaderspot.magnitude - stickDistance);
			
			/*
			//moveSpeed = ((modifiedDistance2*4.0f)/(stickDistance*stickDistance));
			moveSpeed = modifiedDistance2 * 50.0f;
			gameObject.transform.position += gameObject.transform.up * moveSpeed * Time.deltaTime;
			*/
		}
		
	}
	
}
