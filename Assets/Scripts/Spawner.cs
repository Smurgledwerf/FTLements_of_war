using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

	public float cooldown = 5.0f;

	private float lastSpawn = 0.0f;

	// Use this for initialization
	void Start () {
		lastSpawn = Time.time + cooldown;
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.time > lastSpawn + cooldown) {
			spawnEnemy ();
		}
		// just for fun and testing
		else if(Input.GetKeyDown(KeyCode.Space)){
			spawnEnemy();
		}
	}

	private void spawnEnemy(){
		GameObject enemy = Instantiate (Resources.Load ("Enemy"), transform.position, transform.rotation) as GameObject;
		enemy.GetComponent<Enemy> ().OnSpawn ();
		lastSpawn = Time.time;
	}
}
