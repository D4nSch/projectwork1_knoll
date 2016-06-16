using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class MP_PlayerController : NetworkBehaviour {

	private Rigidbody rb;
	public float jumpheight;
	private bool grounded = true;

	// Use this for initialization
	void Start () {

		rb = GetComponent<Rigidbody> ();

	}

	// Update is called once per frame
	void Update () {

		if(!isLocalPlayer) {
			return;
		}

		Camera.main.transform.position = new Vector3 (transform.position.x, 
			transform.position.y+8, 
			transform.position.z-12);

		float x = Input.GetAxis("Horizontal") * Time.deltaTime*150.0f;
		float z = Input.GetAxis("Vertical") * Time.deltaTime*5.0f;

		transform.Rotate(0,x,0);
		transform.Translate(0,0,z);

		if(Input.GetKeyDown("space")){
			if (grounded)
			{
				
				rb.AddForce(Vector3.up * jumpheight);
				//grounded = false;
			}
		}
	}


	public override void OnStartLocalPlayer() {
		GetComponent<MeshRenderer> ().material.color = Color.yellow;
	}
}
