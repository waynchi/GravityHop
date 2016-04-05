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
        transform.position += new Vector3(20, 0, 0) * Time.deltaTime;
	}

    void OnBecomeInvisible()
    {
        Vector3 pos = transform.position;
        float x = pos.x - Background.rectTransform.rect.width * 2;
        gameObject.transform.position = new Vector3(x, 0, 0);
    }
}
