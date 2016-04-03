using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {

	public float speed;
	public float jumpheight;

	public Text counttext;

	private Rigidbody rb;
	private int count;

    private bool grounded = true;

	public Trigger1 trigger1;

    void Start() {
		
		rb = GetComponent<Rigidbody> ();
		count = 0;
		SetCountText ();        
    }

	void FixedUpdate() {

		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);

		rb.AddForce (movement * speed);

		if(Input.GetKeyDown("space")){
            if (grounded)
            {
                
                rb.AddForce(Vector3.up * jumpheight);
                //grounded = false;
            }
		}
	}

	void OnCollisionEnter(Collision collisionInfo) {

		if (collisionInfo.gameObject.CompareTag ("TriggerPlat1")) {

			trigger1.GetComponent<Trigger1> ().enabled = true;

		}

		if (collisionInfo.gameObject.CompareTag ("FinishPlat")) {

			SceneManager.LoadScene("EndScreen");

		}
	}

	void OnTriggerEnter(Collider other) {

		if (other.gameObject.CompareTag ("PickUps")) {

			other.gameObject.SetActive (false);
			count = count + 1;
			SetCountText ();		
		}
	}

    void OnCollisionStay(Collision collisionInfo)
    {
        grounded = true;
    }

    void OnCollisionExit(Collision collisionInfo)
    {
        grounded = false;
    }

    void SetCountText () {
		counttext.text = "Score: " + count.ToString ();
		if (count == 10) {
            SceneManager.LoadScene("EndScreen"); //this will load our first level from our build settings. "1" is the second scene in our game
            
        }
	}
}