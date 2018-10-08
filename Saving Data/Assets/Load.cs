using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Load : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider p) //will be a main menu click() for a "Load" button
	{
		if (p.gameObject.tag == "Player") 
		{
			//save game
			//PlayerPrefs.SetInt("health", es.GetComponent<GameManager>().health);
			GameManager.manage.Load();
			//Debug.Log ("Load");
		}
	}
}
