using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class StarScript : MonoBehaviour {

	int numOfLevels = 15;

	// Use this for initialization
	void Start () {
		Sprite starSprite;

		for (int i = 0; i < numOfLevels; i++) {
			switch (PlayerPrefs.GetInt("Level" + (i+1).ToString())) {

			case 0:
				starSprite = Resources.Load<Sprite> ("three_stars_empty");
				break;
			case 1:
				starSprite = Resources.Load<Sprite> ("one_star");
				break;
			case 2:
				starSprite = Resources.Load<Sprite> ("two_stars");
				break;
			case 3:
				starSprite = Resources.Load<Sprite> ("three_stars");
				break;
			default:

				starSprite = Resources.Load<Sprite> ("three_stars_empty");
				break;
			}
			string levelStars = "LevelMenu/Level" + (i + 1).ToString () + "/Stars";
			GameObject.Find (levelStars).GetComponent<Image> ().sprite = starSprite;
		}
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
