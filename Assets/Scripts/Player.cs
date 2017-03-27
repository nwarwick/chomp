using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour {
	private float score = 0;
	public Text uiScore; // Score display


	// Use this for initialization
	void Start () {
		uiScore = GameObject.Find("PlayerScore").GetComponent<Text>();
	}

	// Increment the players score and display it on the UI
	public void IncrementScore(float amount)
	{
		score+=amount;
		uiScore.text = "Score: " + score.ToString();
	}
}
