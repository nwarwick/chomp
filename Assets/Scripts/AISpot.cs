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
        if (AIControls.state == 1 && other.gameObject.tag == "Food")
		{	// the searching worm has found food to eat
			AIControls.target = other.gameObject;
			AIControls.state = 2;
		}
		else if (AIControls.state == 2 && other.gameObject.tag == "Food")
		{	// if it's already eating, it'll queue this food to eat after

			if (AIControls.foodQueue1 == null)
				AIControls.foodQueue1 = other.gameObject;
			else if (AIControls.foodQueue2 == null)
				AIControls.foodQueue2 = other.gameObject;
			else
				AIControls.foodQueue3 = other.gameObject;
			
			//AIControls.foodQueue.Enqueue(other.gameObject); // this is what we'd LIKE to be doing, intead of a hard-coded set of objects pretending to be a queue
		}
    }
}
