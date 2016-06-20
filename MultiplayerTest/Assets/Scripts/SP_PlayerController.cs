using UnityEngine;
using System.Collections;

public class SP_PlayerController : MonoBehaviour {

	private Rigidbody rb;
	public float jumpheight;
	private bool isGrounded = true;

	// Use this for initialization
	void Start () {

		rb = GetComponent<Rigidbody> ();

	}

	// Update is called once per frame
	void Update () {
		
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
}