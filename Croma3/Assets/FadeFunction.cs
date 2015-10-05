using UnityEngine;
using System.Collections;

public class FadeFunction : MonoBehaviour
{
	string nameScene;
	float alpha;
	int state;
	SpriteRenderer sprite;
	// Use this for initialization
	void Awake ()
	{
		sprite = GetComponent<SpriteRenderer> ();
		alpha = 1;
		state = 0;
		sprite.color = BackgroundColor.invertColorText;
	}

	public void OnFadeLoadLevel(string name)
	{
		nameScene = name;
		state++;
	}
	
	// Update is called once per frame
	void Update ()
	{
		Color color = sprite.color;
		color.a = alpha;
		sprite.color = color;
		if(state % 2 == 0)
		{
			alpha -= Time.deltaTime;
			if(alpha < 0)alpha = 0;
		}
		else
		{
			alpha += Time.deltaTime;
			if(alpha > 1)
			{
				alpha = 1;
				Application.LoadLevel(nameScene);
			}
		}
	}

}
