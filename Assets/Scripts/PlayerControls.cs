using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerControls : MonoBehaviour 
{
	public Head head;

	void Start() 
	{
		head = GetComponent<Head> ();
	}
	
	void FixedUpdate () 
	{
		var mousePosition = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);
		//float mouseDistance = mousePosition.y*mousePosition.y + mousePosition.x * mousePosition.x;	// (actually distance squared)
		
		head.turnTowards(mousePosition);

		//head.moveSpeed = (mouseDistance)/((2000f)*(head.topSpeed*head.topSpeed));	// 2000f was chosen so that the worm will hit maximum speed at about 4 grid-squares away
		
		if (Input.GetMouseButtonDown (0)) 
		{
			head.boost();
		}
	}
}
