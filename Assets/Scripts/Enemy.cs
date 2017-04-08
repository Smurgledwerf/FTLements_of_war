using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

	public float health = 10.0f;
	//public float speed = 1.0f;
	public float damage = 1.0f;

	private Transform center;
	private float maxHealth;
	private HealthBar healthBar;

	// Use this for initialization
	void Start () {
		maxHealth = health;
		center = transform.Find ("Center");
		setDest ();
	}
	
	// Update is called once per frame
	void Update () {
		//Move ();
	}

	public void OnSpawn(){
		// spawn a health bar
		GameObject healthBarObj = Instantiate (Resources.Load ("HealthBar"), transform.position, transform.rotation) as GameObject;
		healthBar = healthBarObj.GetComponent<HealthBar> ();
		healthBar.OnSpawn (this);
	}

	public Transform GetCenter(){
		return center;
	}

	public void takeDamage(float amount){
		health -= amount;
		if (health <= 0) {
			DestroyObject (gameObject);
		}
		if (healthBar != null) {
			healthBar.UpdateHealth (health / maxHealth);
		}
	}

	//[RequireComponent (typeof (UnityEngine.AI.NavMeshAgent))]
	public void setDest(){
		Transform dest = GameObject.FindWithTag ("Destination").transform;
		UnityEngine.AI.NavMeshAgent nav = GetComponent<UnityEngine.AI.NavMeshAgent> ();
		nav.SetDestination(dest.position);
	}
}
