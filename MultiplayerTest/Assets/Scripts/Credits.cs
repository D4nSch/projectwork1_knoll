using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;


public class Credits : MonoBehaviour {

	public GameObject camera;
	public int speed = 1;

	
	// Update is called once per frame
	void Update () {
		camera.transform.Translate (Vector3.down * Time.deltaTime * speed);
	}

	IEnumerator waitFor() {

		yield return new WaitForSeconds (20);
		SceneManager.LoadScene("StartMenu");
	}
}
