using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Contains and deals with core worm components for both Player and AI worms
public class Worm : MonoBehaviour {
 	public Head head;
	public Tail[] bodyParts;
	public AudioManager am;

    void Awake()
    {
        bodyParts = GetComponentsInChildren<Tail>();
    }
	// Use this for initialization
	void Start () {
		head = gameObject.GetComponentInChildren<Head>();
		
		am = GameObject.Find("AudioManager").GetComponent<AudioManager>();
	}
	
	void Update() { }

    public void Kill()
    {


        head.deadAngle = new Vector3(Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f), 0f);
        head.dead = true;
		head.gameObject.GetComponent<Collider2D>().enabled = false;

        for (int i = 0; i < bodyParts.Length; i++)
        {	// this is more elegant, but something broke it
            bodyParts[i].deadAngle = new Vector3(Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f), 0f);
            bodyParts[i].dead = true;
			bodyParts[i].GetComponent<Collider2D>().enabled = false;
        }

        
        /*neck.GetComponent<Tail>().deadAngle = new Vector3(Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f), 0f);
        neck.GetComponent<Tail>().dead = true;
		neck.GetComponent<Collider2D>().enabled = false;

        tail0.GetComponent<Tail>().deadAngle = new Vector3(Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f), 0f);
        tail0.GetComponent<Tail>().dead = true;
		tail0.GetComponent<Collider2D>().enabled = false;
		
        tail1.GetComponent<Tail>().deadAngle = new Vector3(Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f), 0f);
        tail1.GetComponent<Tail>().dead = true;
		tail1.GetComponent<Collider2D>().enabled = false;

        tail2.GetComponent<Tail>().deadAngle = new Vector3(Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f), 0f);
        tail2.GetComponent<Tail>().dead = true;
		tail2.GetComponent<Collider2D>().enabled = false;

        tail3.GetComponent<Tail>().deadAngle = new Vector3(Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f), 0f);
        tail3.GetComponent<Tail>().dead = true;
		tail3.GetComponent<Collider2D>().enabled = false;*/
		if (gameObject.tag == "Player")
		{
			am.PlaySound("Death");
		}
        Destroy(gameObject, 1f);
    }
}
