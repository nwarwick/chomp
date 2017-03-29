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
/*		if (AIControls.state == 2 && other.gameObject.tag == "Food")
		{	// if it's already eating, it'll eat this new food after
			// AIControls.foodqueue.Enqueue(other.gameObject); // THIS DOESN"T WORK FOR SOME REASON
		}*/
    }
}
