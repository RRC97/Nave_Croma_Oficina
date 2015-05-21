using UnityEngine;
using System.Collections;
using System.IO;

public class GameManager : MonoBehaviour
{
	[SerializeField]
	Object cubeBase;

	float timeInstance;

	void Start()
	{

	}
	
	// Update is called once per frame
	void Update ()
	{
		timeInstance += Time.deltaTime;

		if(timeInstance > 0.5f)
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
		
	}
}
