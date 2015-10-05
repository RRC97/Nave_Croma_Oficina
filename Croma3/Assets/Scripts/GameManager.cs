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
	Text totalScore, streak;

	[SerializeField]
	InputButton pauseButton;

	[SerializeField]
	SpriteRenderer[] lifeIcons;

	[SerializeField]
	Sprite textureON, textureOFF;

	[SerializeField]
	PausedScript paused;

	[SerializeField]
	InputManager input;

	[SerializeField]
	GoverManager gover;

	bool pause;
	float timeInstance, timeScale;
	int countPoints, countHits, life = 3,
	countInstance, minColor = 1, multi = 1;

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
			
			//if(countInstance % 5 == 0 && Random.Range(0, 3) != 0)
			//{
			//	instance.AddComponent<BreakStreak>();
			//	instance.GetComponent<BreakStreak>().SetColor(Random.Range(minColor, 5));
			//}
			//else if(countInstance % 7 == 0 && Random.Range(0, 2) != 0)
			//{
			//	instance.AddComponent<PowerUp>();
			//	instance.GetComponent<PowerUp>().SetColor(Random.Range(minColor, 5));
			//}
			//else
			//{
				instance.AddComponent<CubeScript>();
				instance.GetComponent<CubeScript>().SetColor(Random.Range(minColor, 5));
			//}
			
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
                Pause();
			}
			else
			{
				Application.LoadLevel("Game");
			}
		}

		if(pauseButton.IsClicked() && !pause)
		{
			Pause();
		}

		input.enabled = life > 0 ? !pause : false;
	}

    public void Pause()
    {
		if(!gover.gameObject.activeSelf)
		{
	        if (!pause)
	        {
				paused.Travelling();
	            pause = true;
	            timeScale = Time.timeScale;
	            Time.timeScale = 0;
	        }
			else
			{
				paused.Travelling();
				pause = false;
				Time.timeScale = timeScale;
			}
		}
    }

	void PointManager()
	{
		int valueHit = bar.GetValueHit();
		
		if(valueHit > 0)
		{
			int total = 0;
			for(int i = 0; i < valueHit - 1; i++)
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
		InputGame();

		if(!pause)
		{
			InstanceCube();
			PointManager();
		}

		for(int i = 0; i < lifeIcons.Length; i++)
		{
			if(i < life)
			{
                lifeIcons[i].sprite = textureON;
                lifeIcons[i].color = BackgroundColor.colorText;
			}
			else
			{
				lifeIcons[i].sprite = textureOFF;
                lifeIcons[i].color = Color.white;
			}
		}

		if(life <= 0 && !gover.gameObject.activeSelf)
		{
			timeScale = Time.timeScale;
			Time.timeScale = 0;
			gover.gameObject.SetActive(true);

			int best = PlayerPrefs.GetInt("Best");
			PlayerPrefs.SetInt("Score", countPoints);
			if(best < countPoints)
				PlayerPrefs.SetInt("Best", countPoints);
		}

		totalScore.text = countPoints.ToString();
		streak.text = countHits.ToString();
	}
}
