using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	private bool selecting = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (selecting) {
			// drag select stuff
		}
		else if (Input.GetMouseButtonDown(0)) {
			// check what's being clicked on
		}
	}

}
