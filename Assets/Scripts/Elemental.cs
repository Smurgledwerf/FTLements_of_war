using UnityEngine;
using System.Collections;

public class Elemental : MonoBehaviour {

	public float damage = 1.0f;
	public float range = 20.0f;
	public float cooldown = 1.0f;

	private Enemy currentTarget = null;
	private float lastAttack = 0.0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (currentTarget == null) {
			currentTarget = getClosestEnemy ();
		} else if (isInRange (currentTarget)) {
			if (Time.time > lastAttack + cooldown) {
				spawnProjectile ();
				lastAttack = Time.time;
			}
		}
	}

	private Enemy getClosestEnemy(){
		float closest = Mathf.Infinity;
		GameObject enemy = null;
		foreach(GameObject obj in GameObject.FindGameObjectsWithTag("Enemy")){
			Vector3 direction = (obj.transform.position - transform.position);
			RaycastHit hitInfo;
			if (Physics.Raycast (transform.position, direction.normalized, out hitInfo, 500.0f)) {
				if (hitInfo.collider.tag != "Enemy") {
					continue;
				}
				float dist = direction.sqrMagnitude;
				if (dist < closest) {
					closest = dist;
					enemy = obj;
				}
			}
		}

		if (enemy != null) {
			//print (enemy.name);
			return enemy.GetComponentInParent<Enemy>();
		}
		return null;
	}

	private bool isInRange(Enemy target){
		// TODO: this should check line of sight as well
		float dist = (target.transform.position - transform.position).sqrMagnitude;
		return dist < (range * range);
	}

	private void spawnProjectile(){
		GameObject projectile = Instantiate (Resources.Load ("Projectile"), transform.position, new Quaternion(0, 0, 0, 0)) as GameObject;
		projectile.GetComponent<Projectile> ().setTarget (currentTarget.gameObject, damage);
	}
}
