using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class CameraControllerMP : NetworkBehaviour {

	public GameObject player;
	public Camera camera;

	private Vector3 offset;

	void Awake()
    {
    	transform.parent = null;
    }

	// Use this for initialization
	void Start () {
			
    	//if(!isLocalPlayer){
		//	return;
		//}
		offset = transform.position;

	}
	
	// LateUpdate is called once per frame - after Update
	void LateUpdate () {

		player = GameObject.Find("PlayerTest(Clone)");

		transform.position = player.transform.position + offset;

	}
}
