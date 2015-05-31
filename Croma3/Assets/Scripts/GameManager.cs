using UnityEngine;
using System.Collections;
using System.IO;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
	[SerializeField]
	Object cubeBase;

	[SerializeField]
	BarScript bar;

	[SerializeField]
	Text totalScore;

	[SerializeField]
	InputButton pauseButton;

	[SerializeField]
	SpriteRenderer[] lifeIcons;

	[SerializeField]
	Sprite textureON, textureOFF;

	[SerializeField]
	GameObject paused;

	[SerializeField]
	InputManager input;

	bool pause;
	float timeInstance, timeScale;
	int countPoints, countHits, life,
	countInstance, minColor = 1, multi = 1;

	void Start()
	{
		SpriteRenderer rendererPauseButton = 
			pauseButton.GetComponent<SpriteRenderer>();

		rendererPauseButton.color = 
			totalScore.color = 
				BackgroundColor.colorText;
		life = lifeIcons.Length;
	}

	public void SetDouble(bool active)
	{
		if(active)
		{
			multi = 2;
			minColor = 4;
		}
		else
		{
			multi = 1;
			minColor = 1;
		}
	}

	public void AddSweep(int hits)
	{
		int total = 0;
		for(int i = 0; i < hits; i++)
		{
			countHits++;

			int value = 10;

			if(countHits > 100)
				value += 20;
			else if(countHits > 50)
				value += 15;
			else if(countHits > 30)
				value += 10;
			else if(countHits > 10)
				value += 5;
			
			if(countHits % 50 == 0 && life < 3)
				life++;

			total += value;
		}

		total = (int)(total / 0.7f);

		countPoints += total;
	}

	void InstanceCube()
	{
		timeInstance += Time.deltaTime;
		
		if(timeInstance > 1f)
		{
			countInstance++;
			GameObject instance = (GameObject)Instantiate(cubeBase);
			
			if(countInstance % 5 == 0 && Random.Range(0, 3) != 0)
			{
				instance.AddComponent<BreakStreak>();
				instance.GetComponent<BreakStreak>().SetColor(Random.Range(minColor, 5));
			}
			else if(countInstance % 7 == 0 && Random.Range(0, 2) != 0)
			{
				instance.AddComponent<PowerUp>();
				instance.GetComponent<PowerUp>().SetColor(Random.Range(minColor, 5));
			}
			else
			{
				instance.AddComponent<CubeScript>();
				instance.GetComponent<CubeScript>().SetColor(Random.Range(minColor, 5));
			}
			
			instance.transform.parent = this.transform;
			timeInstance = 0;
		}
	}

	void InputGame()
	{
		if(Input.GetKeyDown(KeyCode.Escape))
		{
			if(life > 0)
			{
				if(!pause)
				{
					pause = true;
					timeScale = Time.timeScale;
					Time.timeScale = 0;
				}
				else
				{
					pause = false;
					Time.timeScale = timeScale;
				}
			}
			else
			{
				Application.LoadLevel("Menu");
			}
		}

		if(pauseButton.IsClicked() && !pause)
		{
			pause = true;
			timeScale = Time.timeScale;
			Time.timeScale = 0;
		}

		input.enabled = life > 0 ? !pause : false;
	}

	void PointManager()
	{
		int valueHit = bar.GetValueHit();
		
		if(valueHit > 0)
		{
			int total = 0;
			for(int i = 0; i < valueHit; i++)
			{
				countHits++;
				
				int value = 10;
				
				if(countHits > 100)
					value += 20;
				else if(countHits > 50)
					value += 15;
				else if(countHits > 30)
					value += 10;
				else if(countHits > 10)
					value += 5;
				
				if(countHits % 50 == 0 && life < 3)
					life++;
				
				total += value * multi;
			}
			countPoints += total;
		}
		else if (valueHit < 0)
		{
			countHits = 0;
			life--;
		}
	}
	
	// Update is called once per frame
	void Update ()
	{
		totalScore.color = BackgroundColor.colorText;
		
		InputGame();
		paused.SetActive(pause);

		if(!pause)
		{
			InstanceCube();
			PointManager();
		}

		for(int i = 0; i < lifeIcons.Length; i++)
		{
			if(i < life)
			{
				if(lifeIcons[i].sprite != textureON)
					lifeIcons[i].sprite = textureON;
			}
			else
			{
				if(lifeIcons[i].sprite != textureOFF)
					lifeIcons[i].sprite = textureOFF;
			}
		}

		if(life <= 0)
		{
			timeScale = Time.timeScale;
			Time.timeScale = 0;
		}

		totalScore.text = countPoints.ToString();
		//streak.text = countHits.ToString();
	}
}
