using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour {
	private float score = 0;
	public Text uiScore; // Score display
	public Text uiChargeStatus; // Charge status
	public Head head;
	//public Tail[] bodyParts;


	// Use this for initialization
	void Start () {
		uiScore = GameObject.Find("PlayerScore").GetComponent<Text>();
		uiChargeStatus = GameObject.Find("ChargeStatus").GetComponent<Text>();
		head = gameObject.GetComponentInChildren<Head>();
		//bodyParts = GetComponentsInChildren<Tail>();
		//Debug.Log(bodyParts);
	}

	// Increment the players score and display it on the UI
	public void IncrementScore(float amount)
	{
		score+=amount;
		uiScore.text = "Score: " + score.ToString();
		HighScoreTracker.lastScore = score;
	}

	// Update the charge status text
	void HandleChargeStatus()
	{
		if(head.coolCurrent <= 0)
		{
			uiChargeStatus.text = "Charge ready!";
			return;
		} 
		uiChargeStatus.text = "";
	}

	void Update()
	{
		HandleChargeStatus();
	}
}
