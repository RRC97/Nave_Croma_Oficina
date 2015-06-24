using UnityEngine;
using System.Collections;

public class CubeScript : MonoBehaviour
{
	Vector3 rotateSpeed;

	[SerializeField]
	float downSpeed = 5;

	AudioSource audio;
	Renderer renderer;
	Rigidbody rigidbody;

	protected int colorId;
	// Use this for initialization
	void Awake ()
	{
		audio = GetComponent<AudioSource> ();
		renderer = GetComponent<Renderer> ();
		rigidbody = GetComponent<Rigidbody> ();

		int rSX = Random.Range (1, 4);
		int rSY = Random.Range (1, 4);
		int rSZ = Random.Range (1, 4);

		rSX = Random.Range(0, 2) == 0 ? -rSX : rSX;
		rSY = Random.Range(0, 2) == 0 ? -rSY : rSY;
		rSZ = Random.Range(0, 2) == 0 ? -rSZ : rSZ;

		rotateSpeed = new Vector3 (rSX, rSY, rSZ);
	}
	protected void Start()
	{
		audio.clip = (AudioClip)Resources.Load("Sound/" + renderer.material.mainTexture.name + "_fall");

		int index = PlayerPrefs.GetInt("SettingSound", 0);
		float volume = 1 - 0.35f * index;
		
		if(volume < 0)
			volume = 0;
		
		audio.volume = volume;
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
		Vector3 position = transform.position;
		position.x = Random.Range(-2f, 2f);
		rigidbody.AddForce (Random.Range (-10f * (2 + position.x), 10f * (2 - position.x)), 0, 0);
		transform.position = position;
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
		{
			Destroy (gameObject);
		}
	}

	void FixedUpdate ()
	{
		transform.Rotate(rotateSpeed);

		Vector3 velocity = rigidbody.velocity;
		velocity.y = -downSpeed;
		rigidbody.velocity = velocity;
	}

	public void OnDestroySound ()
	{
		string colorName = renderer.material.mainTexture.name;
		GameObject soundDestroy = (GameObject)Instantiate(Resources.Load("Prefab/CubeEffect"));
		soundDestroy.name = colorName + "_SOUND_DESTROY";
		soundDestroy.transform.position = transform.position;
		soundDestroy.GetComponent<ParticleSystem> ().GetComponent<Renderer> ().material = renderer.material;
		AudioSource audioDestroy = soundDestroy.AddComponent<AudioSource>();

		audioDestroy.clip = (AudioClip)Resources.Load("Sound/" + renderer.material.mainTexture.name + "_destroy");
		
		int index = PlayerPrefs.GetInt("SettingSound", 0);
		float volume = 1 - 0.35f * index;
		
		if(volume < 0)
			volume = 0;
		
		audioDestroy.volume = volume;
		audioDestroy.Play();
	}
}
