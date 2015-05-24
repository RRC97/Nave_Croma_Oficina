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

	float timeInstance;
	int countPoints, countHits, countInstance, minColor = 1, multi = 1;

	void Start()
	{
		totalScore.color = streak.color = BackgroundColor.colorText;
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

			total += value;
		}

		total = (int)(total / 0.7f);

		countPoints += total;
	}
	
	// Update is called once per frame
	void Update ()
	{
		totalScore.color = streak.color = BackgroundColor.colorText;

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

		if(Input.GetKeyDown(KeyCode.Escape))
		{
			Application.LoadLevel("Menu");
		}

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
				
				total += value * multi;
			}
			countPoints += total;
		}
		else if (valueHit < 0)
			countHits = 0;

		totalScore.text = countPoints.ToString();
		streak.text = countHits.ToString();
	}
}
