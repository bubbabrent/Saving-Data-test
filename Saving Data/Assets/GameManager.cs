using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour 
{

	public int health;
	public Text healthText;

	// Use this for initialization
	void Start ()
	{
		DontDestroyOnLoad (gameObject);

		//health = 100;
		PlayerPrefs.GetInt("health");
	}
	
	// Update is called once per frame
	void Update () 
	{
		healthText.text = health.ToString();

		if (Input.GetKey (KeyCode.Q))
			health--;
		if (Input.GetKey (KeyCode.E))
			health++;
	}
}
