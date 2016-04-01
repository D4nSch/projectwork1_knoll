using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {

	public float speed;
	public float jumpheight;

	public Text counttext;
	public Text wintext;

	private Rigidbody rb;
	private int count;

	void Start() {
		
		rb = GetComponent<Rigidbody> ();
		count = 0;
		SetCountText ();
		wintext.text = "";
	}

	void FixedUpdate() {

		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);

		rb.AddForce (movement * speed);

		if(Input.GetKeyDown("space")){
			rb.AddForce(Vector3.up * jumpheight);
		}
	}

	void OnTriggerEnter(Collider other) {

		if (other.gameObject.CompareTag ("PickUps")) {

			other.gameObject.SetActive (false);
			count = count + 1;
			SetCountText ();		
		}
	}

	void SetCountText () {
		counttext.text = "Score: " + count.ToString ();
		if (count == 7) {
            SceneManager.LoadScene("EndScreen"); //this will load our first level from our build settings. "1" is the second scene in our game
            
            //wintext.text = "YOU WIN!";

        }
	}
}