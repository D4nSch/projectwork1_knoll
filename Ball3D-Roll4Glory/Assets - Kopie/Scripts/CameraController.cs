using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	public GameObject player;

	private Vector3 offset;

	// Use this for initialization
	void Start () {

		offset = transform.position - player.transform.position;
	}

	void Update () {
		transform.Translate(Vector3.forward * Time.deltaTime*1);

	}
	
	// LateUpdate is called once per frame - after Update
	void LateUpdate () {
	

		transform.position = player.transform.position + offset;

	}
}
