using UnityEngine;
using System.Collections;

public class ShowEducation : MonoBehaviour
{
	[SerializeField]
	private FadeFunction fade;
	private float time;
	private bool ok;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		time += Time.deltaTime;
		if(time > 3 && !ok)
		{
			ok = true;
			fade.OnFadeLoadLevel("Menu");
		}
	}
}
