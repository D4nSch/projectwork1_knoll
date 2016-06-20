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
		System.Console.WriteLine("test");
	}
	
	// Update is called once per frame
	void FixedUpdate() {
		if (!isLocalPlayer) {
			return;
		} else {
			gameObject.name = "LocalPlayer";
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
		if (level == 8){
			this.transform.position = GameObject.Find(spawnPosname).transform.position;
			spawnPos = GameObject.Find(spawnPosname).transform.position;
			GetComponent<Rigidbody>().velocity = new Vector3(0f,0f,0f); 
            GetComponent<Rigidbody>().angularVelocity = new Vector3(0f,0f,0f);
		}
	}

	void CheckRespawn(){
		if(transform.position.y <= -10){
			transform.position = spawnPos;
			GetComponent<Rigidbody>().velocity = new Vector3(0f,0f,0f); 
            GetComponent<Rigidbody>().angularVelocity = new Vector3(0f,0f,0f);
		}
	}
}		