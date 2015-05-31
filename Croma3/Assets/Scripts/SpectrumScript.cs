using UnityEngine;
using System.Collections;

public class SpectrumScript : MonoBehaviour
{
	private LineRenderer line;

	[SerializeField]
	private AudioSource sound, music;
	// Use this for initialization
	void Start ()
	{
		line = GetComponent<LineRenderer>();
	}
	
	// Update is called once per frame
	void Update ()
	{
		/*float[] soundOutput = new float[128];
		sound.GetSpectrumData(soundOutput, 0, FFTWindow.Rectangular);

		foreach(float output in soundOutput)
			print (output);*/

		float[] musicOutput = new float[1024];
		musicOutput = music.GetOutputData(1024, 0);
		float[] output = new float[128];

		for(int i = 0; i < 1024; i++)
		{
			output[i % 128] += musicOutput[i];
		}

		for(int i = 0; i < output.Length; i++)
		{
			output[i] /= 1024/128;
		}

		for(int i = 0; i < 128; i++)
		{
			float x = -4f + ((i/129f) * 8f);
			float y = 2 + output[i] * 5;
			line.SetPosition(i, new Vector3(x, y, 10));
		}

		//foreach(float output in musicOutput)
		//	print (output);
	}
}
