using UnityEngine;
using System.Collections;

public class SpectrumScript : MonoBehaviour
{
	private LineRenderer line;

	// Use this for initialization
	void Start ()
	{
		line = GetComponent<LineRenderer>();
		Color color = BackgroundColor.colorText;
		color.a = 0.25f;
		line.SetColors(color, color);
	}
	
	// Update is called once per frame
	void FixedUpdate ()
	{
		float[] spectrumOutput = new float[1024];
		spectrumOutput = AudioListener.GetOutputData(1024, 0);
		float[] output = new float[128];

		for(int i = 0; i < 1024; i++)
		{
			output[i % 128] += spectrumOutput[i];
		}

		for(int i = 0; i < output.Length; i++)
		{
			output[i] /= 1024/128;
		}

		for(int i = 0; i < 128; i++)
		{
			float y = 5f - ((i/129f) * 7.5f);
			float x = 3f + output[i] * 5f;
			line.SetPosition(i, new Vector3(x, y, 10));
		}
	}
}
