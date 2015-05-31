using UnityEngine;
using System.Collections;

public class CubeScript : MonoBehaviour
{
	Vector3 rotateSpeed;

	[SerializeField]
	float downSpeed = 5;

	protected int colorId;
	// Use this for initialization
	void Awake ()
	{
		int rSX = Random.Range (1, 4);
		int rSY = Random.Range (1, 4);
		int rSZ = Random.Range (1, 4);

		rSX = Random.Range(0, 2) == 0 ? -rSX : rSX;
		rSY = Random.Range(0, 2) == 0 ? -rSY : rSY;
		rSZ = Random.Range(0, 2) == 0 ? -rSZ : rSZ;

		rotateSpeed = new Vector3 (rSX, rSY, rSZ);
	}
	void Start()
	{
		audio.clip = (AudioClip)Resources.Load("Sound/" + renderer.material.mainTexture.name);
		audio.Play();
	}

	protected void ChangeColor(int newColor)
	{
		int colorChange = -1;

		if(newColor > 5)
			colorChange = 0;
		else
			colorChange = newColor;

		string textureName = "white";
		
		switch(colorChange)
		{
		case 0:
			textureName = "yellow";
			break;
		case 1:
			textureName = "red";
			break;
		case 2:
			textureName = "blue";
			break;
		case 3:
			textureName = "orange";
			break;
		case 4:
			textureName = "green";
			break;
		case 5:
			textureName = "magenta";
			break;
		}
		
		colorId = colorChange;
		renderer.material.mainTexture = (Texture)Resources.Load ("Texture/" + textureName);
	}

	public void SetColor(int color)
	{
		int colorChange = -1;
		if(color >= 4)colorChange = Random.Range(3, 6);
		else colorChange = color - 1;
		string textureName = "white";
		
		switch(colorChange)
		{
		case 0:
			textureName = "yellow";
			break;
		case 1:
			textureName = "red";
			break;
		case 2:
			textureName = "blue";
			break;
		case 3:
			textureName = "orange";
			break;
		case 4:
			textureName = "green";
			break;
		case 5:
			textureName = "magenta";
			break;
		}

		colorId = colorChange;
		renderer.material.mainTexture = (Texture)Resources.Load ("Texture/" + textureName);
		rigidbody.AddForce (Random.Range (-30f, 30f), 0, 0);
	}

	protected void ChangeAlpha(float alpha)
	{
		Color color = renderer.material.color;
		color.a = alpha;
		renderer.material.color = color;
	}

	// Update is called once per frame
	protected void Update ()
	{
		if (transform.position.y <= -10)
			Destroy (gameObject);
	}

	void FixedUpdate ()
	{
		transform.Rotate(rotateSpeed);

		Vector3 velocity = rigidbody.velocity;
		velocity.y = -downSpeed;
		rigidbody.velocity = velocity;
	}
}
