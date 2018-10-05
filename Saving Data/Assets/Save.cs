using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Save : MonoBehaviour {

	GameObject es;

	// Use this for initialization
	void Start () {
		es = GameObject.Find("EventSystem");
	}
	
	// Update is called once per frame
	void Update () {
	}

	void OnTriggerEnter(Collider p)
	{
		if (p.gameObject.tag == "Player") 
		{
			//save game
			PlayerPrefs.SetInt("health", es.GetComponent<GameManager>().health);
		}
	}


}
