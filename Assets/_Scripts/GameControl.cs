using UnityEngine;
using System.Collections;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class GameControl : MonoBehaviour {


	// ==========================================================================
	// Variables
	// ==========================================================================

	public static GameControl control;						// Can be accessed from other scripts

	public float health;													// Float to store health
	public float experience;											// Float to store experience


	// ==========================================================================
	// Functions
	// ==========================================================================

	// Runs before Start()
	void Awake () {
		if (control == null) {											// If control doesnt exist
			DontDestroyOnLoad(gameObject);						// Persist this object
			control = this;														// Make control this
		} else if (control != this) {								// If control does exist but is not equal to this
			Destroy(gameObject);											// Destory that gameObject instance
		}
	}

	// GUI
	void OnGUI () {
		GUI.Label(new Rect(10, 10, 100, 30), "Health: " + health);							// Create a rectangle on GUI that shows health
		GUI.Label(new Rect(10, 40, 100, 30), "Experience: " + experience);			// Create a rectangle on GUI that shows experience
	}

	// Allow other classes to save - public
	public void Save () {
		BinaryFormatter bf = new BinaryFormatter();
		// Works on Windows, Mac, OS, Android
		FileStream file = File.Create(Application.persistentDataPath + "/playerInfo.dat");				// Create a file playerInfo.dat to save data

		PlayerData data = new PlayerData();
			data.health = health;
			data.experience = experience;

		bf.Serialize(file, data);					// Serialize data
		file.Close();
	}

	// Allow other classes to load - public
	public void Load () {
		if (File.Exists(Application.persistentDataPath + "/playerInfo.dat")) {
			BinaryFormatter bf = new BinaryFormatter();
			FileStream file = File.Open(Application.persistentDataPath + "/playerInfo.dat", FileMode.Open);				// Open a file playerInfo.dat to load data
			PlayerData data = (PlayerData)bf.Deserialize(file);
			file.Close();

			health = data.health;
			experience = data.experience;
		}
	}

}

[Serializable]				// Serializable
class PlayerData {


	// ==========================================================================
	// Variables
	// ==========================================================================

	public float health;													// Float to store health
	public float experience;											// Float to store experience

}
