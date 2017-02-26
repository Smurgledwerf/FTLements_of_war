using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

	public float health = 10.0f;
	//public float speed = 1.0f;
	public float damage = 1.0f;
	public Transform center;

	// Use this for initialization
	void Start () {
		center = transform.Find ("Center");
		setDest ();
	}
	
	// Update is called once per frame
	void Update () {
		//Move ();
	}

	//private void Move(){
	//	transform.Translate (Vector3.right * speed * Time.deltaTime);
	//}

	public void takeDamage(float amount){
		health -= amount;
		if (health <= 0) {
			DestroyObject (gameObject);
		}
	}

	//[RequireComponent (typeof (UnityEngine.AI.NavMeshAgent))]
	public void setDest(){
		Transform dest = GameObject.FindWithTag ("Destination").transform;
		UnityEngine.AI.NavMeshAgent nav = GetComponent<UnityEngine.AI.NavMeshAgent> ();
		nav.SetDestination(dest.position);
	}
}
