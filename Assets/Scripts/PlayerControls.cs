using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerControls : MonoBehaviour 
{
	public HeadMovement headMovement;

	void Start() 
	{
		headMovement = GetComponent<HeadMovement> ();
	}
	
	void FixedUpdate () 
	{
		var mousePosition = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);
		float mouseDistance = mousePosition.y*mousePosition.y + mousePosition.x * mousePosition.x;	// (actually distance squared)
		
		headMovement.turnTowards(mousePosition);

		headMovement.moveSpeed = (mouseDistance)/((2000f)*(headMovement.topSpeed*headMovement.topSpeed));	// 2000f was chosen so that the worm will hit maximum speed at about 4 grid-squares away
		
		if (Input.GetMouseButtonDown (0)) 
		{
			headMovement.boost();
		}
	}
}
