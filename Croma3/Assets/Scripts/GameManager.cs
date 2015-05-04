using UnityEngine;
using System.Collections;
using System.IO;

public class GameManager : MonoBehaviour
{
	Object cubeBase;
	public static int levelSelected = 2;
	int level;
	float limitedMax, cooldown;
	float limitedMin, timePlay;
	bool activeMusic;
	public AudioSource music;
	float[] intensitive;
	float nowMax, nowMin, timeInstance;
	float[] samples;
	Color[] colors;
	int lastIndexColor = 0;
	// Use this for initialization
	void Awake ()
	{
		cubeBase = Resources.Load ("Prefab/Cube");
		colors = new Color[]{Color.blue, Color.red, Color.grey, Color.yellow};
		limitedMax = limitedMin = Time.maximumDeltaTime / 10;
		level = levelSelected;
	}

	void Start()
	{
		audio.Play();
	}
	
	// Update is called once per frame
	void Update ()
	{
		if(timePlay < 1.2f)
		timePlay += Time.deltaTime;
		else if(!activeMusic)
		{
			activeMusic = true;
			music.Play();
		}
		if(0.5f > timeInstance)
		{
			timeInstance += (Time.deltaTime);
			return;
		}
		float[] samples = audio.GetOutputData(256, 0);
		intensitive = new float[4];
		for(int i = 0; i < intensitive.Length; i++)
		{
			for (int j = (samples.Length/4) * i; j < (samples.Length/4) * (i + 1); j++)
			{
					Debug.DrawLine(new Vector3(j * 0.01f, 0), new Vector3(j * 0.01f, samples[j]), colors[i]);
				intensitive[i] += samples[j];
			}
			intensitive[i] /= (samples.Length/4);
		}
		int countLastIndexColor = 0;
		for(int i = 0; i < intensitive.Length; i++)
		{
			if(intensitive[i] * timeInstance > limitedMax * (10 / level))
			{
				GameObject instance = (GameObject)Instantiate(cubeBase);
				instance.GetComponent<CubeScript>().SetColor(i + 1);
				instance.transform.parent = this.transform;
				timeInstance = 0;
				lastIndexColor = i + 1;
				countLastIndexColor++;
				break;
			}
			else if(intensitive[i] * timeInstance < -limitedMin * (10 / level))
			{
				GameObject instance = (GameObject)Instantiate(cubeBase);
				instance.GetComponent<CubeScript>().SetColor(4 - i);
				instance.transform.parent = this.transform;
				timeInstance = 0;
				lastIndexColor = 4 - i;
				countLastIndexColor++;
				break;
			}
		}
		/*float[] samples = audio.GetOutputData(256, 0);
		float average = 0;
		foreach (float sample in samples) {
			average += sample;
		}
		average /= samples.Length;

		if(average != 0)
			value++;

		nowTimeSample = audio.timeSamples;


		if(value % 50 == 0)
			result = nowTimeSample - lastTimeSample;

		lastTimeSample = nowTimeSample;
		/*intensitive = new float[size];
		for(int i = 0; i < output.Length; i++)
		{
			int index = (int)(i / (output.Length/intensitive.Length));
			intensitive[index] += -output[i];
		}

		for(int i = 0; i < intensitive.Length; i++)
		{
			float result = intensitive[i]/(output.Length/intensitive.Length) * Mathf.Pow(10, level);
			print(result);
			if(result > limited)
				selectedCube[i] = true;
		}

		for(int i = 0; i < 4; i++)
		{
			if(selectedCube[i])
			{
				GameObject instance = (GameObject)Instantiate(cubeBase);
				instance.GetComponent<CubeScript>().SetColor(i + 1);
				instance.transform.parent = this.transform;
				selectedCube[i] = false;
			}
		}
		intensitive = new float[4];
		float[] spectrum = audio.GetSpectrumData(64, 0, FFTWindow.Rectangular);
		Vector3 lastVector = new Vector3(5.12f, 0);

		for(int i = 1; i < 63; i++)
		{
			float Hetz = spectrum[i];//* Time.deltaTime;
			Vector3 newVector = new Vector3(lastVector.x - (i + 1) * 0.001f, Hetz);
			Debug.DrawLine(lastVector, newVector, Color.yellow);
			int index = (int)(i / 16);
			intensitive[index] += (int)Hetz;
			lastVector = newVector;
		}
		for(int i = 0; i < 4; i++)
		{
			if(limited <= (int)(intensitive[i] * Mathf.Pow(10, i * level)))
			{
				print ("value: " + intensitive[i] * Mathf.Pow(10, i * level));
				selectedCube[i] = true;
			}
		}
		for(int i = 0; i < 4; i++)
		{
			if(selectedCube[i])
			{
				GameObject instance = (GameObject)Instantiate(cubeBase);
				instance.GetComponent<CubeScript>().SetColor(i + 1);
				instance.transform.parent = this.transform;
				selectedCube[i] = false;
			}
		}*/

		if(Input.GetKeyDown(KeyCode.Escape))
		{
			Application.LoadLevel("Level");
		}
		
	}
}
