using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class respawnTest : MonoBehaviour {

    private Vector3 startPos;
	// Use this for initialization
	void Start () {
        startPos = GameObject.Find("Player").transform.position;
    }
	
	// Update is called once per frame
	void Update () {
        if (transform.position.y < -10)
        {
            //SceneManager.LoadScene("RollerBaller");
            transform.position = startPos;
            GetComponent<Rigidbody>().velocity = new Vector3(0f,0f,0f); 
            GetComponent<Rigidbody>().angularVelocity = new Vector3(0f,0f,0f);
            GetComponent<PlayerController>().ReduceLives();
        }
    }
}
