using UnityEngine;
using System.Collections;

public class BarScript : MonoBehaviour
{
	string spriteName;
	int valueHit;

	Vector3 defaultScaleBarEffect;
	float scaleEffect;

	[SerializeField]
	private SpriteRenderer barEffect;

	private bool effect;
	private SpriteRenderer spriteRenderer;

	public void Awake()
	{
		spriteName = "white";

		spriteRenderer = GetComponent<SpriteRenderer>();

		defaultScaleBarEffect = transform.localScale;
		defaultScaleBarEffect.x = 0;
		scaleEffect = 0;
		effect = false;
		spriteRenderer.color = barEffect.color = GetColor(spriteName);
	}

	public void ResetSprite(string newSpriteName)
	{
		if(!spriteName.Equals(newSpriteName) && !effect)
		{
			spriteRenderer.color = GetColor(spriteName);
			spriteName = newSpriteName;
			effect = true;
		}
	}

	Color GetColor(string name)
	{
		Color colorResult = BackgroundColor.colorText;

		switch(name)
		{
		case "yellow":
			colorResult = GameColors.YELLOW;
			break;
		case "red":
			colorResult = GameColors.RED;
			break;
		case "blue":
			colorResult = GameColors.BLUE;
			break;
		case "orange":
			colorResult = GameColors.ORANGE;
			break;
		case "green":
			colorResult = GameColors.GREEN;
			break;
		case "magenta":
			colorResult = GameColors.MAGENTA;
			break;
		}

		return colorResult;
	}

	void FixedUpdate()
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
				spriteRenderer.sprite = barEffect.sprite;
				spriteRenderer.color = barEffect.color;
				scaleEffect = 1;
			}
		}

		barEffect.transform.localScale = Vector3.Lerp(defaultScaleBarEffect, transform.localScale, scaleEffect);
	}

	void OnTriggerEnter(Collider c)
	{
		Renderer rendererCollider = c.gameObject.GetComponent<Renderer> ();
		if(rendererCollider.material.mainTexture.name.Equals(spriteName))
		{
			Collided(c);
		}
	}



	void OnTriggerStay(Collider c)
	{
		Renderer rendererCollider = c.gameObject.GetComponent<Renderer> ();
		if(rendererCollider.material.mainTexture.name.Equals(spriteName))
		{
			Collided(c);
		}
	}

	void Collided (Collider c)
	{
		PowerUp powerUp = c.GetComponent<PowerUp>();
		BreakStreak breakStreak = c.GetComponent<BreakStreak>();
		CubeScript cubeScript = c.GetComponent<CubeScript>();
		
		if(powerUp != null)
			powerUp.OnAction();
		if(breakStreak != null)
			valueHit ++;
		valueHit ++;
		
		cubeScript.OnDestroySound ();
		Destroy(c.gameObject);
	}

	void OnTriggerExit(Collider c)
	{
		PowerUp powerUp = c.GetComponent<PowerUp>();

		if(powerUp == null)
			valueHit = -1;
	}

	public int GetValueHit()
	{
		int result = valueHit;
		valueHit = 0;
		return result;
	}
}
