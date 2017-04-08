using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour {

	public float height = 2.25f;

	private Enemy enemy;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (enemy != null) {
			Vector3 pos = enemy.transform.position;
			transform.position = pos + (Vector3.up * height);
		} else {
			Destroy (gameObject);
		}
	}

	public void OnSpawn(Enemy spawner){
		enemy = spawner;
	}

	public void UpdateHealth(float newHealth){
		transform.localScale = new Vector3 (newHealth, 1, 1);
	}
}
