using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDeath : MonoBehaviour {

	float timer = 0;
	bool armed = false;
	
	void Update () {
		
		if (Input.GetKeyDown(KeyCode.Escape))
		{
            SceneManager.LoadScene("MainMenu");
		}
		
		if (timer > 0)
			timer -= Time.deltaTime;
		
		if (armed && timer <= 0)
			SceneManager.LoadScene("MainMenu");
	}
	
	public void returnToMenu()
	{
		armed = true;
		timer = 1.15f;
	}
	
}
