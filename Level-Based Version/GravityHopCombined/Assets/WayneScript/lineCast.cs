using UnityEngine;
using System.Collections;

public class lineCast : MonoBehaviour {

	private LineRenderer lineRenderer;
	private NewPlayerController playerController;
	private Rigidbody2D UFO;
	private GameObject direction;
	private CentralStateScript stateMachine;
	private Quaternion _facing;
	public Transform laserHit;

	// Use this for initialization
	void Start () {
		lineRenderer = GetComponent<LineRenderer> ();
		lineRenderer.enabled = true;
		lineRenderer.useWorldSpace = true;
		stateMachine = GameObject.FindGameObjectWithTag("SM").GetComponent<CentralStateScript>();
		direction = (GameObject)Instantiate(Resources.Load("direction"), laserHit.position + new Vector3(0, transform.localScale.x * 0.5f, 0), laserHit.rotation);
		_facing = direction.transform.rotation;
	}

	// Update is called once per frame
	void Update () {
		//RaycastHit2D hit = Physics2D.Raycast (transform.position, transform.up);
		//Debug.DrawLine (transform.position, hit.point);
		//laserHit.position = hit.point;
		if (stateMachine.getMovement() == CentralStateScript.Movement.Flight) {
			lineRenderer.enabled = false;
		} else if (stateMachine.getMovement() == CentralStateScript.Movement.Orbit) {
			lineRenderer.enabled = true;
		}

		if (UFO == null) {
			UFO = GameObject.FindGameObjectWithTag ("Player").GetComponent<Rigidbody2D> ();
			if (UFO == null) {
				return;
			}
			playerController = UFO.GetComponent<NewPlayerController> ();
		}
		transform.position = UFO.position + playerController.BurstDirecton;
		laserHit.position = (Vector2)transform.position + playerController.BurstDirecton / 10;
		lineRenderer.SetPosition (0, transform.position);
		lineRenderer.SetPosition (1, laserHit.position);
		/*direction.transform.position = laserHit.position;
		Quaternion rotation = Quaternion.LookRotation(playerController.BurstDirecton.normalized);
		rotation.x = 0f;
		rotation.y = 0f;
		direction.transform.rotation = rotation;*/
		//direction.transform.rotation = Quaternion.LookRotation(playerController.BurstDirecton.normalized) * _facing;

	}
}
