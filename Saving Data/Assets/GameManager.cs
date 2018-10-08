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

	//All in-game player and game stats that need to be saved should be here
	//----------
	public int health;
	//current inventory item?
	//----------
	public Text healthText;

	void Awake()
	{
		if (manage == null) 
		{
			DontDestroyOnLoad (gameObject);
            Debug.Log("manage was null");
			manage = this;
			health = 100;
		} 
		else if (manage != this) 
		{
            Debug.Log("manage exists");
            Destroy (gameObject);
		}
	}

	// Update is called once per frame
	void Update () 
	{
        //Cursor.lockState = CursorLockMode.Locked;
        //Cursor.visible = false;


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
		FileStream file = File.Create(Application.persistentDataPath + "/playerInfo.dat");

		PlayerData data = new PlayerData ();
		data.health = health;

		bf.Serialize (file, data);
		file.Close ();
		Debug.Log ("Save");
	}

	public void Load()
	{
		//So right now the game will simply either load, or NOT load when the button is clicked, based off of a possible existing file.
		//This will be reworked later to check early on (probably in Awake) if there is a file or not. If not, then the load button will not show up on Main Menu
		if (File.Exists (Application.persistentDataPath + "/playerInfo.dat")) 
		{
			BinaryFormatter bf = new BinaryFormatter ();
			FileStream file = File.Open(Application.persistentDataPath + "/playerInfo.dat", FileMode.Open);
			PlayerData data = (PlayerData)bf.Deserialize (file);
			file.Close ();

			health = data.health;
			Debug.Log ("Load");
		}
	}
}

//all saved stats should be duplicated into here, so they can properly be saved. These specific versions are to grab the stats from in-game or file, and store/open them in a file/game
[Serializable]
class PlayerData
{
	public int health;

}
