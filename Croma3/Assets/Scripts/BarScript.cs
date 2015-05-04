using UnityEngine;
using System.Collections;

public class BarScript : MonoBehaviour
{
	string spriteName;
	int valueHit;

	public void Awake()
	{
		spriteName = "white";
	}

	public void ResetSprite(string newSpriteName)
	{
		SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
		Sprite sprite = Resources.Load<Sprite>("Texture/" + newSpriteName);
		spriteRenderer.sprite = sprite;
		spriteName = newSpriteName;
	}

	void OnTriggerEnter(Collider c)
	{
		if(c.gameObject.renderer.material.mainTexture.name.Equals(spriteName))
		{
			valueHit ++;
			Destroy(c.gameObject);
			Handheld.Vibrate();
		}
	}
	void OnTriggerStay(Collider c)
	{
		if(c.gameObject.renderer.material.mainTexture.name.Equals(spriteName))
		{
			valueHit ++;
			Destroy(c.gameObject);
			Handheld.Vibrate();
		}
	}

	public int GetValueHit()
	{
		return valueHit;
	}
}
