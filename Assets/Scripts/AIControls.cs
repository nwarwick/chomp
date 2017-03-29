using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIControls : MonoBehaviour {
	
	public Head head;
	public int state; // 0 Testing; 1 Wandering; 2 Grazing
	
	public GameObject target;	// the object the ai is currently moving towards, if any
	public GameObject foodQueue1; // these variables SHOULD be a queue, but I can't seem to get that to work
	Vector3 destination; // the location the ai is moving towards, when it doesn't have an object target
	
	// adjust these two floats if the size of the map changes
	// (maybe they can somehow be fetched from the game management object during Start() or something, to allow for variable board sizes?)
	public float xBound = 80f;
	public float yBound = 80f;
	float wanderTimer;
	
	void Start() 
	{
		head = GetComponent<Head> ();
		state = 1;
		SetRandomDestination();
	}
	
	void SetRandomDestination()
	{
		destination = new Vector3(Random.Range(-xBound, xBound), Random.Range(-yBound, yBound), 0f);
		wanderTimer = Random.Range(3.0f, 25.0f);
	}
	
	void FixedUpdate () 
	{
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
			if (target == null)
			{
				if (foodQueue1 == null)
				{
					state = 1;
					SetRandomDestination();
				}
				else
				{
					target = foodQueue1;
				}
			}
			
			destination = target.transform.position - head.transform.position;
			head.turnTowards(destination);
			
			head.moveSpeed = head.topSpeed;
		}
		
		
		// at the moment, te AI doesn't boost*/
	}
}
