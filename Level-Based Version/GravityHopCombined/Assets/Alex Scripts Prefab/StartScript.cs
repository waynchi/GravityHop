using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class StartScript : MonoBehaviour {

	int numOfLevels = 4;

	// Use this for initialization
	void Start () {
		PlayerPrefs.DeleteAll ();
		for (int i = 0; i < numOfLevels; i++) {
			if (!PlayerPrefs.HasKey ("Level"+(i+1).ToString())) {
				PlayerPrefs.SetInt ("Level" + (i+1).ToString(), 2);
			}
		}


	}

	public void LoadLevel(int level)
	{
		// BuildIndex
		// 0: Start Screen
		// 1: level1
		SceneManager.LoadScene(level);
	}
}
