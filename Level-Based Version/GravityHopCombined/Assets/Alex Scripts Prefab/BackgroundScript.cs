using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BackgroundScript : MonoBehaviour {

    Image Background;

	// Use this for initialization
	void Start () {
        Background = GetComponent<Image>();
	}
	
	// Update is called once per frame
	void Update () {
        transform.position += new Vector3(0.2f, 0, 0) * Time.deltaTime;
	}

    void OnBecomeInvisible()
    {
        gameObject.transform.position = new Vector3(-22, 0, 0);
    }
}
