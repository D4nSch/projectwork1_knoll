using UnityEngine;
using System.Collections;

public class CameraMovingZ : MonoBehaviour {

	public Transform startMarker;
	public Transform endMarker;
	public float speed = 1.0F;
	private float startTime;
	private float journeyLength;

	public Camera followCam;
	public Camera zoomInCam;

	//public CharacterController cc;


	// Use this for initialization
	void Start () {

		//cc = GetComponent<CharacterController>();

		//cc.enabled = false;

		followCam.GetComponent<Camera>().enabled = false;
		zoomInCam.GetComponent<Camera>().enabled = true;

		startTime = Time.time;
		journeyLength = Vector3.Distance(startMarker.position, endMarker.position);

	}
	
	// Update is called once per frame
	void Update () {

		float distCovered = (Time.time - startTime) * speed;
		float fracJourney = distCovered / journeyLength;
		transform.position = Vector3.Lerp(startMarker.position, endMarker.position, fracJourney);

	
	}

	void LateUpdate () {

		if (transform.position == endMarker.transform.position) {
			zoomInCam.GetComponent<Camera> ().enabled = false;
			followCam.GetComponent<Camera> ().enabled = true;
			//cc.enabled = true;
		}
	}
}
