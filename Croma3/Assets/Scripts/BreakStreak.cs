using UnityEngine;
using System.Collections;

public class BreakStreak : CubeScript
{
	private int type, side;
	private float timeEffect, alpha;
	// Use this for initialization
	void Start ()
	{
		base.Start();
		type = 1;//Random.Range(0, 2);
		alpha = 1;
		if(type == 1)
		{
		}
	}
	
	// Update is called once per frame
	void Update ()
	{
		base.Update();
		float lastTimeEffect = timeEffect;
		timeEffect += Time.deltaTime;

		if(type == 0)
		{
			if(alpha <= 0)
			{
				alpha = 0;
				side = -1;
			}
			if(alpha >= 1)
			{
				alpha = 1;
				side = 1;
			}
			
			float diferrenceTime = timeEffect - lastTimeEffect;
				
			if(side > 0)
				alpha -= diferrenceTime;
			if(side < 0)
				alpha += diferrenceTime;
		}

		if(timeEffect >= 1)
		{
			if(type == 1)
			{
				ChangeColor(colorId + 1);
			}
			timeEffect = 0;
		}

		ChangeAlpha(alpha);
	}
}
