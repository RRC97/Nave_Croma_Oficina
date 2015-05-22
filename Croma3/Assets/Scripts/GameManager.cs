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
	int countPoints, countHits;
	
	// Update is called once per frame
	void Update ()
	{
		timeInstance += Time.deltaTime;

		if(timeInstance > 1f)
		{
			GameObject instance = (GameObject)Instantiate(cubeBase);
			instance.GetComponent<CubeScript>().SetColor(Random.Range(1, 5));
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
			countPoints += valueHit * 10;
			countHits++;
		}
		else if (valueHit < 0)
			countHits = 0;

		totalScore.text = countPoints.ToString();
		streak.text = countHits.ToString();
	}
}
