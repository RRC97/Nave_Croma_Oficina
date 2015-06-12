using UnityEngine;
using System.Collections;

public class PowerUpEvent : MonoBehaviour
{
	int type;
	float time;
	private GameManager manager;

	void Start()
	{
		manager = transform.parent.GetComponent<GameManager>();

		switch(type)
		{
		case 0:
			Time.timeScale += 0.2f;
			break;
		case 1:
			manager.SetDouble(true);
			break;
		case 2:
			CubeScript[] normalCubes = GameObject.FindObjectsOfType<CubeScript>();
			BreakStreak[] breakCubes = GameObject.FindObjectsOfType<BreakStreak>();
			PowerUp[] powerCubes = GameObject.FindObjectsOfType<PowerUp>();
			
			int score = 0;
			
			foreach(CubeScript cube in normalCubes)
			{
				Destroy(cube.gameObject);
				cube.OnDestroySound();
				score++;
			}
			foreach(BreakStreak cube in breakCubes)
			{
				Destroy(cube.gameObject);
				cube.OnDestroySound();
				score++;
			}
			foreach(PowerUp cube in powerCubes)
			{
				Destroy(cube.gameObject);
				cube.OnDestroySound();
				score++;
			}
			
			manager.AddSweep(score);
			break;
		}
	}

	public void SetType(int t)
	{
		type = t;
	}

	void Update()
	{
		time += Time.deltaTime;

		if(time > 10)
		{
			if(type == 0)
			{
				Time.timeScale -= 0.2f;
			}
			else if(type == 1)
			{
				manager.SetDouble(false);
			}

			Destroy(this);
		}
	}
}
