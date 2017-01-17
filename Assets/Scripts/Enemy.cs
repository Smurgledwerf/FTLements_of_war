using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

	public float health = 10.0f;
	public float speed = 1.0f;
	public float damage = 1.0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate (Vector3.right * speed * Time.deltaTime);
	}

	public void takeDamage(float amount){
		health -= amount;
		if (health <= 0) {
			DestroyObject (gameObject);
		}
	}
}
