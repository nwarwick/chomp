using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuteMusic : MonoBehaviour {

	public AudioSource musicplayer;
	
	void Update () {
		if (Input.GetKeyDown("m"))
		{
			if (musicplayer.volume > 0.5f)
			{
				MasterVolume.musicVolume = 0f;
			}
			else
			{
				MasterVolume.musicVolume = 1f;
			}
			
			
		}
		musicplayer.volume = MasterVolume.musicVolume;
	}
}
