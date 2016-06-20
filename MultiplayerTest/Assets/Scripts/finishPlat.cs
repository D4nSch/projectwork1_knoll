using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class finishPlat : MonoBehaviour {

	public string nextLevel;

	void OnCollisionEnter(Collision collisionInfo) {
		if (collisionInfo.gameObject.CompareTag ("Player")) {

			SceneManager.LoadScene(nextLevel);

		}
	}
}
