using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

	public float speed = 10.0f;

	private float damage = 1.0f;
	private Enemy target = null;
	private Vector3 direction;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (target != null) {
			direction = target.center.position - transform.position;
		}
		transform.Translate (direction.normalized * speed * Time.deltaTime);
	}

	public void setTarget(GameObject obj, float dmg){
		damage = dmg;
		target = obj.GetComponent<Enemy>();
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
