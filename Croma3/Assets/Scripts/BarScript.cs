using UnityEngine;
using System.Collections;

public class BarScript : MonoBehaviour
{
	string spriteName;
	int valueHit;
	Color yellow, red, green, blue, magenta, orange;
	Vector3 defaultScaleBarEffect;
	float scaleEffect;

	[SerializeField]
	private SpriteRenderer barEffect;

	private bool effect;
	private SpriteRenderer spriteRenderer;

	public void Awake()
	{
		spriteName = "white";
		yellow = new Color(255 / 255f, 211 / 255f, 14 / 255f);
		red = new Color(225 / 255f, 11 / 255f, 19 / 255f);
		green = new Color(86 / 255f, 160 / 255f, 49 / 255f);
		blue = new Color(44 / 255f, 83 / 255f, 160 / 255f);
		magenta = new Color(115 / 255f, 112 / 255f, 179 / 255f);
		orange = new Color(239 / 255f, 123 / 255f, 72 / 255f);

		spriteRenderer = GetComponent<SpriteRenderer>();

		defaultScaleBarEffect = transform.localScale;
		defaultScaleBarEffect.x = 0;
		scaleEffect = 1;
	}

	public void ResetSprite(string newSpriteName)
	{
		if(!spriteName.Equals(newSpriteName))
		{
			spriteRenderer.color = GetColor(spriteName);
			spriteName = newSpriteName;
			effect = true;
		}
	}

	Color GetColor(string name)
	{
		Color colorResult = Color.white;

		switch(name)
		{
		case "yellow":
			colorResult = yellow;
			break;
		case "red":
			colorResult = red;
			break;
		case "blue":
			colorResult = blue;
			break;
		case "orange":
			colorResult = orange;
			break;
		case "green":
			colorResult = green;
			break;
		case "magenta":
			colorResult = magenta;
			break;
		}

		return colorResult;
	}

	void Update()
	{
		if(effect)
		{
			barEffect.color = GetColor(spriteName);
			scaleEffect = 0;
			effect = false;
		}
		else
		{
			if(scaleEffect < 1f)
			{
				scaleEffect += Time.deltaTime * 5;
			}
			else
			{
				spriteRenderer.color = barEffect.color;
				scaleEffect = 1;
			}
		}

		barEffect.transform.localScale = Vector3.Lerp(defaultScaleBarEffect, transform.localScale, scaleEffect);
	}

	void OnTriggerEnter(Collider c)
	{
		if(c.gameObject.renderer.material.mainTexture.name.Equals(spriteName))
		{
			valueHit ++;
			Destroy(c.gameObject);
		}
	}
	void OnTriggerStay(Collider c)
	{
		if(c.gameObject.renderer.material.mainTexture.name.Equals(spriteName))
		{
			valueHit ++;
			Destroy(c.gameObject);
		}
	}

	void OnTriggerExit(Collider c)
	{
		valueHit = -1;
	}

	public int GetValueHit()
	{
		int result = valueHit;
		valueHit = 0;
		return result;
	}
}
