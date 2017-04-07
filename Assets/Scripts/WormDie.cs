using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WormDie : MonoBehaviour
{

    public GameObject head;
    public GameObject neck;
    public GameObject tail0;
    public GameObject tail1;
    public GameObject tail2;
    public GameObject tail3;

    public Player player;

    void Start()
    {
        player = GetComponent<Player>();
    }

    void Update() { }

    public void Kill()
    {


        head.GetComponent<Head>().deadAngle = new Vector3(Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f), 0f);
        head.GetComponent<Head>().dead = true;
		head.GetComponent<Collider2D>().enabled = false;

    /*    for (int i = 0; i < player.bodyParts.Length; i++)
        {	// this is more elegant, but something broke it
            player.bodyParts[i].deadAngle = new Vector3(Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f), 0f);
            player.bodyParts[i].dead = true;
			player.bodyParts[i].GetComponent<Collider2D>().enabled = false;
        }*/

        
        neck.GetComponent<Tail>().deadAngle = new Vector3(Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f), 0f);
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
		tail3.GetComponent<Collider2D>().enabled = false;

        Destroy(gameObject, 1f);
    }
}
