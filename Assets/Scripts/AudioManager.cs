using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.SerializableAttribute]
public class Sound
{
    public string name;
    public AudioClip clip;
    private AudioSource source;


    public void SetSource(AudioSource newSource)
    {
        source = newSource;
        source.clip = clip;
    }

    public void Play()
    {
		source.Play();
    }
}

public class AudioManager : MonoBehaviour
{

	public static AudioManager instance;

	[SerializeField]
    Sound[] sounds;

	void Awake()
	{
		if(instance != null)
		{
			Debug.LogError("Too many audio managers in this scene!");
		} else {
			instance = this;
		}
	}

	
	void Start()
	{
		for(int i = 0; i < sounds.Length; i ++)
		{
			GameObject gObj = new GameObject("Sound_" + i + "_" + sounds[i].name);
			gObj.transform.SetParent(this.transform);
			sounds[i].SetSource( gObj.AddComponent<AudioSource>() );

		}

	}

	public void PlaySound(string _name) 
	{
		for(int i = 0; i < sounds.Length; i ++)
		{
			if(sounds[i].name == _name)
			{
				sounds[i].Play();
				return;
			}
		}

		Debug.Log("AudioManager: " + _name + " Sound not found");
	}
}
