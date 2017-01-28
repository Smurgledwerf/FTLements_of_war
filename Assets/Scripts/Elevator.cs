using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour {

	public float speed = 1.0f;

	private UnityEngine.AI.OffMeshLink offMeshLink;
	private bool atStart = true;
	private bool moving = false;
	private Vector3 destination;
	private UnityEngine.AI.NavMeshAgent rider;

	// Use this for initialization
	void Start () {
		offMeshLink = GetComponentInParent<UnityEngine.AI.OffMeshLink> ();
		destination = offMeshLink.startTransform.position;
	}
	
	// Update is called once per frame
	void Update () {
		if (moving == true) {
			Vector3 direction = (destination - transform.position);
			if (direction.sqrMagnitude <= 0.001f) {
				StopElevator ();
			}
			transform.Translate (direction.normalized * speed * Time.deltaTime);
		}
	}

	void OnTriggerEnter(Collider other){
		// print (other.gameObject.name);
		UnityEngine.AI.NavMeshAgent nav = other.GetComponentInParent<UnityEngine.AI.NavMeshAgent> ();
		if (nav == rider) {
			//nothing?
		}
		else if (other.tag == "Enemy") {
			rider = nav;
			rider.Stop ();
			rider.transform.SetParent (transform);
			rider.transform.position = new Vector3 (transform.position.x, rider.transform.position.y, transform.position.z);
			MoveElevator ();
		}
	}

	public void MoveElevator(){
		if (atStart == true) {
			destination = offMeshLink.endTransform.position;
		} else {
			destination = offMeshLink.startTransform.position;
		}
		moving = true;
	}

	public void StopElevator(){
		moving = false;
		atStart = !atStart;
		rider.transform.SetParent (null);
		rider.Warp (rider.transform.position);
		rider.Resume ();
		print (rider.destination);
		rider.SetDestination (rider.GetComponent<test> ().destination.position);
	}
}
