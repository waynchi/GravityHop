using UnityEngine;
using System.Collections;

public class Restart : MonoBehaviour {


	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void restartNow() {
		UnityEngine.SceneManagement.SceneManager.LoadScene (UnityEngine.SceneManagement.SceneManager.GetActiveScene ().buildIndex);
	}
}
