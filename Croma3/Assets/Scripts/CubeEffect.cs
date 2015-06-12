using UnityEngine;
using System.Collections;

public class CubeEffect : MonoBehaviour
{
	// Update is called once per frame
	void Update ()
	{
		if(!audio.isPlaying && !particleSystem.isPlaying)
			Destroy(this.gameObject);
	}
}
