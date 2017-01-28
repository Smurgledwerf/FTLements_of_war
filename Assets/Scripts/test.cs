using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour {

	public Transform destination;

	// Use this for initialization
	void Start () {
		setDest (destination.position);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	//[RequireComponent (typeof (UnityEngine.AI.NavMeshAgent))]
	public void setDest(Vector3 dest){
		UnityEngine.AI.NavMeshAgent nav = GetComponent<UnityEngine.AI.NavMeshAgent> ();
		nav.SetDestination(dest);
	}
}
