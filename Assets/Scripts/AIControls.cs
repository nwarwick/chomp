using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIControls : MonoBehaviour {
	
	public Head head;
	public int state; // 0 Testing; 1 Wandering; 2 Grazing
	
	public GameObject target;	// the object the ai is currently moving towards, if any
	/*public GameObject foodQueue1; // these variables SHOULD be a queue, but I can't seem to get that to work
	public GameObject foodQueue2;
	public GameObject foodQueue3;*/

	public GameObject gm;
	public Food[] foodList; // List of food objects on the map

	Vector3 destination; // the location the ai is moving towards, when it doesn't have an object target
	
	// adjust these two floats if the size of the map changes
	// (maybe they can somehow be fetched from the game management object during Start() or something, to allow for variable board sizes?)
	public float xBound = 10f;
	public float yBound = 10f;
	float wanderTimer;
	
	void Start() 
	{
		head = GetComponent<Head> ();
		state = 1;
		SetRandomDestination();

		gm = GameObject.Find("GameManager");
		foodList = gm.GetComponent<FoodManager>().foodList; // Get list of food on the map
	}
	
	void SetRandomDestination()
	{
		destination = new Vector3(Random.Range(-xBound, xBound), Random.Range(-yBound, yBound), 0f);
		wanderTimer = Random.Range(3.0f, 25.0f);
	}
	
	void FixedUpdate () 
	{
		// Update list of food on map
		foodList = gm.GetComponent<FoodManager>().foodList;
		// the AI always moves at maxiumum speed, since it has perfect reflexes and doesn't care about precision anyway
		
		if (state == 0)
		{	// TESTING (moves straight right, to make collisions easy)
			Vector3 testPoint = new Vector3(50f, 0f, 0f);
			head.turnTowards(testPoint);
			head.moveSpeed = head.topSpeed;
		}
		else if (state == 1)
		{	// WANDERING (looking for food)
			
			var tempdestination = destination - transform.position;
			if (wanderTimer <= 0.0f)
				SetRandomDestination();
			else if ((tempdestination.x * tempdestination.x) + (tempdestination.y + tempdestination.y) < 3)
				SetRandomDestination();
			
			head.turnTowards(tempdestination);
			wanderTimer -= Time.deltaTime;
			
			head.moveSpeed = head.topSpeed;
		}
		else if (state == 2)
		{	// GRAZING (moving to the nearest food)
			/*if (foodQueue1 == null)
			{	// in case someone else eats his food1, but he still has a food2 queued
				foodQueue1 = foodQueue2;
				foodQueue2 = foodQueue3;
				foodQueue3 = null;
			}*/
				
			if (target == null)
			{
				
				Food newFood = foodList[Random.Range(0, foodList.Length)];

				if (newFood == null) // If no food on map
				{
					state = 1;
					SetRandomDestination();
					head.turnTowards(destination);
					return;
				}
				target = newFood.gameObject;
			}


			
			destination = target.transform.position - head.transform.position;
			head.turnTowards(destination);
			
			head.moveSpeed = head.topSpeed;
		}
		else if (state == 3)
		{	// FLEEING (moving directly away from the other worm, making a swerve and boost if the other gets too close or boosts)
			
			if (target == null)
				state = 1;
			
			float targetDistance2 = destination.x * destination.x + destination.y * destination.y;
			destination = -(target.transform.position - head.transform.position);
			
			if (targetDistance2 < 15.0f)
			{
				// destination altered to create "swerve"?
				head.boost();
			}
			head.turnTowards(destination);
			
			head.moveSpeed = head.topSpeed;
			
			if (targetDistance2 > 150 && head.currentBoost <= 0)
				state = 1;
		}
		else if (state == 4)
		{	// HUNTING (moving directly towards the target, boosting if possible)
			Debug.Log("Attacking!");
			
			if (target == null)
				state = 1;
			
			destination = target.transform.position - head.transform.position;
			head.turnTowards(destination);
			float targetDistance2 = destination.x * destination.x + destination.y * destination.y;
			
			head.moveSpeed = head.topSpeed;
			
			if (targetDistance2 < 30)
			{
				head.boost();
				state = 5;
			}
			else if (targetDistance2 > 150)
				state = 1;
		}
		else if (state == 5)
		{	// CHARGING
			if (head.currentBoost <= 0)
			{
				head.boost();
				state = 5;
			}
		}
	}
}
