using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class StartScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}

    public void StartGame()
    {
        // BuildIndex
        // 0: Start Screen
        // 1: level1
        SceneManager.LoadScene(1);
    }
}
