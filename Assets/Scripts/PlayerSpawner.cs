using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour {

	public GameObject playerWormPrefab; 
	public CameraFollow CameraFollow;
	
	void Start () {
		Vector3 boardMiddle = new Vector3(0f, 0f, 0f);
		GameObject newWorm = Instantiate(playerWormPrefab, boardMiddle, Quaternion.identity);
		CameraFollow.player = newWorm.transform.GetChild(0).gameObject;	// yes yes I know it shouldn't be referenced by index but it's 11:30 at night
	}
	
	
}
