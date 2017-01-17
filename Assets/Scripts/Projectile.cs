using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

	private float damage = 1.0f;
	private float speed = 5.0f;
	private GameObject target = null;
	private Vector3 direction;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (target != null) {
			direction = target.transform.position - transform.position;
		}
		transform.Translate (direction.normalized * speed * Time.deltaTime);
	}

	public void setTarget(GameObject obj, float dmg){
		damage = dmg;
		target = obj;
	}

	void OnCollisionEnter (Collision collision) {
		switch (collision.gameObject.tag) {
		case "Enemy":
			Enemy enemy = collision.gameObject.GetComponent<Enemy> ();
			enemy.takeDamage (damage);
			DestroyObject (gameObject);
			break;
		default:
			break;
		}
	}
}
