using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScoreTracker : MonoBehaviour {

	public Text scoreDisplay;
	public static float highScore = 0;
	public static float lastScore = 0;

	void Start () 
	{
		if (lastScore > highScore)
			highScore = lastScore;
		
		scoreDisplay.text = "High Score: "+highScore+"         Last Score: "+lastScore;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
