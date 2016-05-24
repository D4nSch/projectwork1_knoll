using UnityEngine;
using System.Collections;

public class CameraControllerMP : MonoBehaviour {

	public GameObject player;
	public Camera camera;

	private Vector3 offset;

	// Use this for initialization
	void Start () {
			
		offset = transform.position;

	}
	
	// LateUpdate is called once per frame - after Update
	void LateUpdate () {
		
		player = GameObject.Find("Player(Clone)");

		transform.position = player.transform.position + offset;

	}
}
