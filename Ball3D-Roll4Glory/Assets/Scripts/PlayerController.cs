using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;

public class PlayerController : NetworkBehaviour {

	public float speed;
	public float jumpheight;

	public Text counttext;

	public Text livetext;

	private int lives = 3;

	private Rigidbody rb;
	private int count;

    private bool grounded = true;

	public Trigger1 trigger1;

	public GameObject trap;
    public AudioSource[] audioPickUp;

    void Start() {
		
		rb = GetComponent<Rigidbody> ();
		count = 0;
		SetCountText ();
		SetLiveText();
		trap = GameObject.Find("ItemTrap");
        audioPickUp = new AudioSource[2];
        audioPickUp[0] = GameObject.Find("PickUpSound").GetComponent<AudioSource>();
        audioPickUp[1] = GameObject.Find("EvilPickUpSound").GetComponent<AudioSource>();
    }

	void FixedUpdate() {

		if(!isLocalPlayer){
			this.enabled = false;
			return;
		}
			
		
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
            audioPickUp[0].Play();
            other.gameObject.SetActive (false);
			count = count + 1;
			SetCountText ();

		} else if (other.gameObject.CompareTag("TriggerPickUp1"))
        {
            audioPickUp[1].Play();
            other.gameObject.SetActive(false);
            trap.GetComponent<spawnEntity>().activateTrap();
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
		//if (count == 10) {
        //    SceneManager.LoadScene("EndScreen"); //this will load our first level from our build settings. "1" is the second scene in our game    
        //}
	}

	void SetLiveText() {
		livetext.text = "Leben: " + lives.ToString ();
	}

	public void ReduceLives(){
		lives--;
		SetLiveText();
		if(lives == 0){
			SceneManager.LoadScene("LoseScreen");
		}
	}

	public int GetLives(){
		return lives;
	}
}