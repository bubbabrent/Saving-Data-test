using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class GameManager : MonoBehaviour 
{

	public static GameManager manage;

	public int health;
	public Text healthText;

	void Awake()
	{
		if (manage == null) 
		{
			DontDestroyOnLoad (gameObject);
			manage = this;
			health = 100;
		} 
		else if (manage != this) 
		{
			Destroy (gameObject);
		}
	}

	// Use this for initialization

	void Start ()
	{
		DontDestroyOnLoad (gameObject);

		//health = 100;
		//PlayerPrefs.GetInt("health");
	}
	
	// Update is called once per frame
	void Update () 
	{
		healthText.text = health.ToString();

		if (Input.GetKey (KeyCode.H))
			Debug.Log (health);

		if (Input.GetKey (KeyCode.Q))
			health--;
		if (Input.GetKey (KeyCode.E))
			health++;
	}

	public void Save()
	{
		BinaryFormatter bf = new BinaryFormatter ();
		FileStream file = File.Create(Application.persistentDataPath + "/playerInfo.data");

		PlayerData data = new PlayerData ();
		data.health = health;

		bf.Serialize (file, data);
		file.Close ();
		Debug.Log ("Save");
	}

	public void Load()
	{
		if (File.Exists (Application.persistentDataPath + "/playerInfo.dat")) 
		{
			BinaryFormatter bf = new BinaryFormatter ();
			FileStream file = File.Open(Application.persistentDataPath + "/playerInfo.data", FileMode.Open);
			PlayerData data = (PlayerData)bf.Deserialize (file);
			file.Close ();

			health = data.health;
			Debug.Log ("Load");
		}
	}
}

[Serializable]
class PlayerData
{
	public int health;

}
