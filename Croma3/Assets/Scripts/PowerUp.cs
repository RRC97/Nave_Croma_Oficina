using UnityEngine;
using System.Collections;

public class PowerUp : CubeScript
{
	private int type;
	private Texture aux;

	void Start()
	{
		base.Start();

		type = Random.Range(0, 3);
		renderer.material.SetFloat("_Blend", 1);

		switch(type)
		{
			case 0:
				aux = (Texture)Resources.Load("Texture/rush");
				break;
			case 1:
				aux = (Texture)Resources.Load("Texture/greed");
				break;
			case 2:
				aux = (Texture)Resources.Load("Texture/sweep");
				break;
		}

		renderer.material.SetTexture("_Texture2", aux);
	}

	void Update()
	{
		base.Update();
	}
	public void OnAction()
	{
		GameObject powerEvent = new GameObject("Power Up Event", typeof(PowerUpEvent));
		powerEvent.transform.parent = transform.parent;
		powerEvent.GetComponent<PowerUpEvent>().SetType(type);
	}
}
