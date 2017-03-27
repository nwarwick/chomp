using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour {
	public float scoreWeight = 10;
	public FoodManager foodManager;


	// Use this for initialization
	void Start () {
		if(foodManager == null)
		{
			foodManager = GameObject.Find("GameManager").GetComponent<FoodManager>();
		}

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void DestroyFood(){
		Destroy(gameObject);
	}
}
