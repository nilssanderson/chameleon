using UnityEngine;
using System.Collections;

public class AdjustScript : MonoBehaviour {


	// ==========================================================================
	// Variables
	// ==========================================================================


	// ==========================================================================
	// Functions
	// ==========================================================================

	// GUI
	void OnGUI () {
		if (GUI.Button(new Rect(10, 100, 100, 30), "Health up")) {					// If health up button is clicked
			GameControl.control.health += 10;																	// Increment the health by 10
		}
		if (GUI.Button(new Rect(10, 140, 100, 30), "Health down")) {				// If health down button is clicked
			GameControl.control.health -= 10;																	// Decrement the health by 10
		}
		if (GUI.Button(new Rect(10, 180, 100, 30), "Experience up")) {			// If experience up button is clicked
			GameControl.control.experience += 10;															// Increment the experience by 10
		}
		if (GUI.Button(new Rect(10, 220, 100, 30), "Experience down")) {		// If experience down button is clicked
			GameControl.control.experience -= 10;															// Decrement the experience by 10
		}

		if (GUI.Button(new Rect(10, 260, 100, 30), "Save")) {								// If experience save button is clicked
			GameControl.control.Save();																				// Save the data
		}
		if (GUI.Button(new Rect(10, 300, 100, 30), "Load")) {								// If experience load button is clicked
			GameControl.control.Load();																				// Load the data
		}
	}
}
