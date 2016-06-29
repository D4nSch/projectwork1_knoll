using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;

public class MP_PlayerController_Ball : NetworkBehaviour {

	private Rigidbody rb;
	public float speed;
	public float jumpheight;
	private bool isGrounded = true;
	public int lives;
	public Vector3 spawnPos;
	public string spawnPosname;
	private bool levelchanged = false;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();

		if (GameObject.Find("Spawn Position 1").transform.position == this.transform.position){
			spawnPosname = "Spawn Position 1";
		}else{
			spawnPosname = "Spawn Position 2";
		}
		spawnPos = transform.position;
		DontDestroyOnLoad(gameObject);
	}
	
	// Update is called once per frame
	void FixedUpdate() {
		if (!isLocalPlayer) {
			return;
		} else {
			gameObject.name = "LocalPlayer";
		}

		if (levelchanged){
			levelchanged = false;
			Respawn();
		}

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
		if(isLocalPlayer){
			if (other.gameObject.CompareTag ("PickUps")) {
			other.gameObject.SetActive (false);
			speed *= 1.025f;
			jumpheight *= 1.01f;
			}	
		}
	}


	void OnLevelWasLoaded(int level){
			spawnPos = GameObject.Find(spawnPosname).transform.position;
            speed = 10;
			jumpheight = 250;
			levelchanged = true;
	}

	void CheckRespawn(){
		if(transform.position.y <= -10){
			Respawn();
		}
	}

	void Respawn(){
		transform.position = spawnPos;
		GetComponent<Rigidbody>().velocity = new Vector3(0f,0f,0f); 
        GetComponent<Rigidbody>().angularVelocity = new Vector3(0f,0f,0f);
	}
}		