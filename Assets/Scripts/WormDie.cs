using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WormDie : MonoBehaviour
{

    public GameObject head;
    /*public GameObject neck;
    public GameObject tail0;
    public GameObject tail1;
    public GameObject tail2;
    public GameObject tail3;*/

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

        for (int i = 0; i < player.bodyParts.Length; i++)
        {
            player.bodyParts[i].deadAngle = new Vector3(Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f), 0f);
            player.bodyParts[i].dead = true;
        }

        /* 
        neck.GetComponent<Tail>().deadAngle = new Vector3(Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f), 0f);
        neck.GetComponent<Tail>().dead = true;

        tail0.GetComponent<Tail>().deadAngle = new Vector3(Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f), 0f);
        tail0.GetComponent<Tail>().dead = true;

        tail1.GetComponent<Tail>().deadAngle = new Vector3(Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f), 0f);
        tail1.GetComponent<Tail>().dead = true;

        tail2.GetComponent<Tail>().deadAngle = new Vector3(Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f), 0f);
        tail2.GetComponent<Tail>().dead = true;

        tail3.GetComponent<Tail>().deadAngle = new Vector3(Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f), 0f);
        tail3.GetComponent<Tail>().dead = true;*/

        Destroy(gameObject, 1f);
    }
}
