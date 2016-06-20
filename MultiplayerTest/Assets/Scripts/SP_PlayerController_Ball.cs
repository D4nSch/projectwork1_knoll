using UnityEngine;
using System.Collections;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class SP_PlayerController_Ball : MonoBehaviour {

	private Rigidbody rb;
	public float speed;
	public float jumpheight;
	private bool isGrounded = true;
	public int lives;
	private Vector3 spawnPos;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
		spawnPos = transform.position;
	}
	
	// Update is called once per frame
	void FixedUpdate() {

		Camera.main.transform.position = new Vector3 (transform.position.x, 
			transform.position.y+8, 
			transform.position.z-12);

		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);

		rb.AddForce (movement * speed);

		if(Input.GetKeyDown("space")){
            if (isGrounded)
            {
                rb.AddForce(Vector3.up * jumpheight);
            }
		}
		CheckRespawn();
	}

	void OnCollisionStay(Collision coll){
		isGrounded = true;
	}
	void OnCollisionExit(Collision coll){
		if (isGrounded) {
			isGrounded = false;   
		}
	}

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.CompareTag ("PickUps")) {
			other.gameObject.SetActive (false);
			speed *= 1.025f;
			jumpheight *= 1.01f;
		}
	}

	void CheckRespawn(){
		if(transform.position.y <= -10){
			transform.position = spawnPos;
			GetComponent<Rigidbody>().velocity = new Vector3(0f,0f,0f); 
            GetComponent<Rigidbody>().angularVelocity = new Vector3(0f,0f,0f);
			
			lives--;

			if (lives <= 0){
				Destroy(GameObject.Find("Player"));
				SceneManager.LoadScene("LooseScene");
			}
		}
	}
}