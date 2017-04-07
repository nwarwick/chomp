using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AISpot : MonoBehaviour {

	public AIControls AIControls;
	
	void Start () 
	{	
		AIControls = transform.parent.gameObject.GetComponent<AIControls>();
	}
	
	void Update () {}
	
	void OnTriggerEnter2D(Collider2D other) 
	{
		if(other.gameObject.name == "Head" && AIControls.state != 4)
		{	// if it sees the other worm's head first, it assumes it's being hunted
			AIControls.state = 3;
			AIControls.target = other.gameObject;
			/*AIControls.foodQueue1 = null;
			AIControls.foodQueue2 = null;
			AIControls.foodQueue3 = null;*/
			
		}
		else if (other.gameObject.tag == "Body" && other.gameObject.transform.parent != gameObject.transform.parent.parent && AIControls.state != 3)
		{	// otherwise if it sees the tail first, it sees an opportunity (not its OWN tail, obviously)
			AIControls.state = 4;
			AIControls.target = other.gameObject;
			/*AIControls.foodQueue1 = null;
			AIControls.foodQueue2 = null;
			AIControls.foodQueue3 = null;*/
		}
        else if (AIControls.state == 1 && other.gameObject.tag == "Food")
		{	// the searching worm has found food to eat
			AIControls.target = other.gameObject;
			AIControls.state = 2;
		}
		else if (AIControls.state == 2 && other.gameObject.tag == "Food")
		{	// if it's already eating, it'll queue this food to eat after

			/*if (AIControls.foodQueue1 == null)
				AIControls.foodQueue1 = other.gameObject;
			else if (AIControls.foodQueue2 == null)
				AIControls.foodQueue2 = other.gameObject;
			else
				AIControls.foodQueue3 = other.gameObject;*/
			
			//AIControls.foodQueue.Enqueue(other.gameObject); // this is what we'd LIKE to be doing, intead of a hard-coded set of objects pretending to be a queue
		}
    }
}
