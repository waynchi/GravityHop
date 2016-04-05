using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class NewComboScript : MonoBehaviour {

	public bool ComboInitiated = false;
	public float lastComboTime = 0.0F;
	public float ComboCount = 0, comboTime = 20;
	public string displayComboContent; 

	public Text DisplayCombo;

	public Vector2 MassCenter, LastMassCenter;
	public 

	// Use this for initialization
	void Start () {
		DisplayCombo = GetComponent<Text> ();
	}
	
	// Update is called once per frame
	void Update () {
		DisplayCombo.text = displayComboContent;
	}

	public void Combo(){
		Debug.Log ("Enter Combo");
		if (ComboInitiated) {
			if (Time.time - lastComboTime > comboTime) {
				Debug.Log ("ComboEnded");
				ComboInitiated = false;
				ComboCount = 0;
				displayComboContent = "";
			} else {
				Debug.Log ("Enter Combo: TRUE");
				ComboCount++;
				lastComboTime = Time.time;
				displayComboContent = "Combo: " + ComboCount.ToString () + "  !!!";
			}

		} else {
			Debug.Log ("Enter Combo: FALSE");
			ComboInitiated = true;
			ComboCount = 1;
			lastComboTime = Time.time;
			displayComboContent = "Combo: " + ComboCount.ToString () + "  !!!";
		}
	}
}
