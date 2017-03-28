using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour {
	private float score = 0;
	public Text uiScore; // Score display
	public Text uiChargeStatus; // Charge status
	public HeadMovement headMovement;


	// Use this for initialization
	void Start () {
		uiScore = GameObject.Find("PlayerScore").GetComponent<Text>();
		uiChargeStatus = GameObject.Find("ChargeStatus").GetComponent<Text>();
		headMovement = gameObject.GetComponentInChildren<HeadMovement>();
	}

	// Increment the players score and display it on the UI
	public void IncrementScore(float amount)
	{
		score+=amount;
		uiScore.text = "Score: " + score.ToString();
	}

	// Update the charge status text
	void HandleChargeStatus()
	{
		if(headMovement.coolCurrent <= 0)
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
