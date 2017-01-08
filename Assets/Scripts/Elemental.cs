using UnityEngine;
using System.Collections;

public class Elemental : MonoBehaviour {

	public float damage = 1.0f;
	public float range = 10.0f;
	public float cooldown = 1.0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	private Enemy getClosestEnemy(){
		foreach(GameObject obj in GameObject.FindGameObjectsWithTag("Enemy")){
			float dist = (obj.transform.position - transform.position).sqrMagnitude;
		}
	}
}
