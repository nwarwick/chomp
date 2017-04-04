using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Head : MonoBehaviour 
{
	public Player player;
	// BASIC MOVEMENT VALUES
	public float topSpeed;		// maximum movement speed (when not boosting)
	// BOOST VALUES
	public float boostCoolDown;	// this is the number of seconds before the worm can boost again
	public float boostSpeed;	// how many times faster the boost carries the worm
	public float boostLength;	// how long the boost lasts
	// INTERNAL MOVEMENT VARIABLES
	public float moveSpeed = 20;  // (this is only "public" so playerControls and AI can get at it)
	// INTERNAL BOOST VARIABLES
	public float coolCurrent = 0; // Made public for charge status update
	public float currentBoost = 0;
	
	public bool dead = false;
	public Vector3 deadAngle = new Vector3(0f, 0f, 0f);
	

	
	void Start () {	
		if(player == null){
			player = transform.parent.gameObject.GetComponent<Player>();
		}
		
	}
	
	void FixedUpdate () 
	{
		if (dead)
		{	// if dead
			gameObject.transform.position += deadAngle * Time.deltaTime; // slide in a randomly selected (by WormDie.cs) direction
			transform.Rotate(Vector3.forward * Time.deltaTime * 90f);	// rotate
			transform.localScale += new Vector3(-0.004f, -0.004f, 0);
			

		}
		else
		{
			if (moveSpeed > topSpeed)
				moveSpeed = topSpeed;
		
			if (currentBoost > boostLength - (1.0f/4.0f))
			{	// in the first 1/4 second, we are interpolating up to full boost speed
				var accelFactor = (boostLength-currentBoost)*4.0f;
				moveSpeed = (moveSpeed * (1.0f-accelFactor)) + ((topSpeed * boostSpeed) * (accelFactor));
			}
			else if (currentBoost > (boostLength/2.0f))
			{	// then cruise at full boosted speed until the halfway point
				moveSpeed = topSpeed * boostSpeed;
			}
			else if (currentBoost > 0)
			{	// then interpolate back down to normal travel speed
				var decelFactor = currentBoost / (boostLength/2.0f); // goes from 1 to 0
				moveSpeed = (moveSpeed * (1.0f-decelFactor)) + ((topSpeed * boostSpeed) * (decelFactor));
			}
		
			gameObject.transform.position += gameObject.transform.up * moveSpeed * Time.deltaTime;
		
			if (currentBoost > 0)
				currentBoost -= Time.deltaTime;
			if (currentBoost <= 0 && coolCurrent > 0)
				coolCurrent -= Time.deltaTime;
		}
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
			currentBoost = boostLength;
			coolCurrent = boostCoolDown;
		}
	}

	void OnCollisionEnter2D(Collision2D other)
	{
		if (other.gameObject.tag == "Food")
		{
			Food food = other.gameObject.GetComponent<Food>();
			player.IncrementScore(food.scoreWeight); // Increment score by 10 for food. 
			food.DestroyFood(); // Eat da food
		}
		else if (other.gameObject.tag == "Body" && currentBoost > 0)
		{
			other.transform.parent.GetComponent<WormDie>().Kill();
			// increment the player's score as well
			player.IncrementScore(100);
		}
		else
		{	// if the worm hits somethign that doesn't give way, it looses any boost momentum
			currentBoost = 0;
		}
	}
}
