using UnityEngine;
using System.Collections;

public class AllTriggerOff : MonoBehaviour {

	public Trigger1 trigger1;

	// Use this for initialization
	void Start () {

		trigger1.GetComponent<Trigger1>().enabled = false;
	
	}
}
