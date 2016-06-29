using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;

public class finishPlatNW : NetworkBehaviour {

	public string nextLevel;
	public NetworkLobbyManager mymanager;
	//public Scene nextLevel;

	void Start(){
	    mymanager = GameObject.Find("LobbyManager").GetComponent<NetworkLobbyManager>();
	}

	[ServerCallback]
	void OnCollisionEnter(Collision collisionInfo) {
		if (collisionInfo.gameObject.CompareTag ("Player")) {
			mymanager.autoCreatePlayer = true;
			mymanager.ServerChangeScene (nextLevel);
		}
	}
}
