using UnityEngine;
using System.Collections;

public class CubeEffect : MonoBehaviour
{
	AudioSource audio;
	ParticleSystem particleSystem;

	void Awake ()
	{
		audio = GetComponent<AudioSource> ();
		particleSystem = GetComponent<ParticleSystem> ();
	}
	// Update is called once per frame
	void Update ()
	{
		if(!audio.isPlaying && !particleSystem.isPlaying)
			Destroy(this.gameObject);
	}
}
