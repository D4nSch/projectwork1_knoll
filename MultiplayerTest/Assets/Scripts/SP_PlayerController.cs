using UnityEngine;
using System.Collections;

public class SP_PlayerController : MonoBehaviour {

	private Rigidbody rb;
	public float jumpheight;
	private bool grounded = true;

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
			if (grounded)
			{
				rb.AddForce(Vector3.up * jumpheight);
				//grounded = false;
			}
		}
	}
}