using UnityEngine;
using System.Collections;

public class ExperienceTracker : MonoBehaviour {

	
	// ==========================================================================
	// Variables
	// ==========================================================================

	public int curLevel = 1;
	private int maxLevel;

//	public float curExp = GameControl.control.experience;
	private float maxExp = 100;

	public float expBarLength;

	
	// ==========================================================================
	// Functions
	// ==========================================================================

	// Use this for initialization
	void Start () {
		expBarLength = Screen.width / 2;
	}
	
	// Update is called once per frame
	void Update () {
	
		AdjustCurrentExp (0);

		Debug.Log("curExp " + GameControl.control.experience + " -- Exp " + GameControl.control.experience);

		if (GameControl.control.experience >= maxExp) {
			GameControl.control.experience = 0;
			curLevel++;
			maxExp += (20 * curLevel);
		}
	}

	void OnGUI() {
		GUI.Box (new Rect(20, 50, expBarLength, 20), GameControl.control.experience + " / " + maxExp);
		GUI.Box (new Rect(20, 90, 200, 20), "Level: " + curLevel);
	}

	public void AdjustCurrentExp(float adjExp) {
		GameControl.control.experience += adjExp;

		expBarLength = 200 * (GameControl.control.experience / maxExp);
	}
}
