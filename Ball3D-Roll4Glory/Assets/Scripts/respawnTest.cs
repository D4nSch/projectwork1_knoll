using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class respawnTest : MonoBehaviour {

	// Use this for initialization
	void Start () {

    }
	
	// Update is called once per frame
	void Update () {
        Vector3 playerPos = GameObject.Find("Player").transform.position;
        if (playerPos.y < -10)
        {
            SceneManager.LoadScene("RollerBaller");
        }
    }
}
