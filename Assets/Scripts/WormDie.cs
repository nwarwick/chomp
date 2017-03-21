using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WormDie : MonoBehaviour {

	public GameObject head;
	public GameObject neck;
	public GameObject tail0;
	public GameObject tail1;
	public GameObject tail2;
	public GameObject tail3;
	
	void Start () {	}
	
	void Update () { }
	
	void Kill()
	{
		head.GetComponent<HeadMovement>().deadAngle = new Vector3(Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f), 0f);
		head.GetComponent<HeadMovement>().dead = true;

		neck.GetComponent<TailMovement>().deadAngle = new Vector3(Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f), 0f);
		neck.GetComponent<TailMovement>().dead = true;

		tail0.GetComponent<TailMovement>().deadAngle = new Vector3(Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f), 0f);
		tail0.GetComponent<TailMovement>().dead = true;
		
		tail1.GetComponent<TailMovement>().deadAngle = new Vector3(Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f), 0f);
		tail1.GetComponent<TailMovement>().dead = true;
		
		tail2.GetComponent<TailMovement>().deadAngle = new Vector3(Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f), 0f);
		tail2.GetComponent<TailMovement>().dead = true;
		
		tail3.GetComponent<TailMovement>().deadAngle = new Vector3(Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f), 0f);
		tail3.GetComponent<TailMovement>().dead = true;
		
		Destroy (gameObject, 1f);
	}
}
