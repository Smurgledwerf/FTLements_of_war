using UnityEngine;
using System.Collections;

public class Elemental : MonoBehaviour {

	public enum ElementalType
	{
		Water,
		Fire,
		Earth,
		Wind
	};

	public ElementalType element;
	public float damage = 1.0f;
	public float range = 20.0f;
	public float cooldown = 1.0f;

	private Enemy currentTarget = null;
	private float lastAttack = 0.0f;
	private Transform projectileSpawn;

	// Use this for initialization
	void Start () {
		projectileSpawn = transform.Find ("ProjectileSpawn");
	}
	
	// Update is called once per frame
	void Update () {
		if (currentTarget == null) {
			currentTarget = getClosestEnemy ();
		} else if (isValidTarget (currentTarget)) {
			if (Time.time > lastAttack + cooldown) {
				spawnProjectile ();
				lastAttack = Time.time;
			}
		} else {
			currentTarget = null;
		}
	}

	private Enemy getClosestEnemy(){
		float closest = Mathf.Infinity;
		GameObject enemy = null;
		foreach(GameObject obj in GameObject.FindGameObjectsWithTag("Enemy")){
			Vector3 direction = (obj.transform.position - transform.position);
			if (!hasLineOfSight(obj)){
				continue;
			}
			float dist = direction.sqrMagnitude;
			if (dist < closest) {
				closest = dist;
				enemy = obj;
			}
		}

		if (enemy != null) {
			//print (enemy.name);
			return enemy.GetComponentInParent<Enemy>();
		}
		return null;
	}

	private bool hasLineOfSight (GameObject target){
		Vector3 direction = (target.transform.position - transform.position);
		RaycastHit hitInfo;
		if (Physics.Raycast (transform.position, direction, out hitInfo, 500.0f)) {
			if (hitInfo.collider.tag == "Enemy") {
				return true;
			}
		}
		return false;
	}

	private bool isInRange(GameObject target){
		float dist = (target.transform.position - transform.position).sqrMagnitude;
		return dist < (range * range);
	}

	private bool isValidTarget(Enemy target){
		bool lineOfSight = hasLineOfSight (target.gameObject);
		bool inRange = isInRange (target.gameObject);
		return inRange && lineOfSight;
	}

	private void spawnProjectile(){
		GameObject projectile = Instantiate (Resources.Load ("Projectile"), projectileSpawn.position, new Quaternion(0, 0, 0, 0)) as GameObject;
		projectile.GetComponent<Projectile> ().OnSpawn (currentTarget.gameObject, damage, element);
	}
}
