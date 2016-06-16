using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.Networking;

public class MP_PlayerController : NetworkBehaviour {

	private Rigidbody rb;
	public float jumpheight;
	private bool isGrounded = true;
	//public Text counttext;
	//private int count;

	// Use this for initialization
	void Start () {

		rb = GetComponent<Rigidbody> ();

	}
				
	// Update is called once per frame
	void Update () {

		if (!isLocalPlayer) {
			return;
		} else {
			gameObject.name = "LocalPlayer";
		}

		Camera.main.transform.position = new Vector3 (transform.position.x, 
			transform.position.y+8, 
			transform.position.z-12);

		float x = Input.GetAxis("Horizontal") * Time.deltaTime*150.0f;
		float z = Input.GetAxis("Vertical") * Time.deltaTime*5.0f;

		transform.Rotate(0,x,0);
		transform.Translate(0,0,z);

		if(Input.GetKeyDown("space")){
			if (isGrounded==true)
			{
				
				rb.AddForce(Vector3.up * jumpheight);
				//grounded = false;
			}
		}
	}

	void OnCollisionStay(Collision coll){
		isGrounded = true;
	}
	void OnCollisionExit(Collision coll){
		if (isGrounded) {
			isGrounded = false;   
		}
	}


	public override void OnStartLocalPlayer() {
		GetComponent<MeshRenderer> ().material.color = Color.yellow;
	}

	void OnTriggerEnter(Collider other) {

		if (other.gameObject.CompareTag ("PickUps")) {
			//audioPickUp [0].Play ();
			other.gameObject.SetActive (false);
			//count = count + 1;
			SetCountText ();

		}
	}

	void SetCountText () {
		//counttext.text = "Score: " + count.ToString ();
	}
}
