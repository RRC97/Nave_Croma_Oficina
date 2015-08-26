using UnityEngine;
using System.Collections;

public class MenuBar : MonoBehaviour
{
	private Vector3 position;
	private bool posCorrect;
	private float aux;
	private bool on = true;
	// Use this for initialization
	void Awake ()
	{
		position = transform.position;
		transform.position = position;
	}

	public void TravilingOff()
	{
		aux = 0;
		posCorrect = on = false;
	}
	
	// Update is called once per frame
	void FixedUpdate ()
	{
		aux += Time.deltaTime;

		if(on) position.y = Mathf.Lerp(position.y, -3.5f, 0.1f);
		else position.y = Mathf.Lerp(position.y, -15f, 0.1f);

		if(aux >= 1f)
			posCorrect = true;
		else posCorrect = false;

		foreach(MenuButton button in
        transform.GetComponentsInChildren<MenuButton> (true))
		{
			button.enabled = posCorrect;
		}
		
		transform.position = position;
	}
}
