using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets._2D;

public class Weapon : MonoBehaviour {

	public float damage = 10;		//sets damage
	public float maxDamage = 15;
	public float chargeSpeed = 1;
	public LayerMask whatToHit;		//what do we hit?
	public float timeToSpawnEffect = 0;
	public int direction = 1;

	public Transform bulletTrailPrefab;

	bool charging = false;
	float timeToFire = 0;
	Transform firePoint;

	void Awake() {
		firePoint = transform.FindChild ("firePoint");
		if (firePoint == null) {
			Debug.LogError ("No Fire Point attached");
		}
	}

	// Update is called once per frame
	void Update () {

		if (Input.GetKey (KeyCode.D)) {
			direction = 1;
		} else if (Input.GetKey (KeyCode.A)) {
			direction = -1;
		}

		if (Input.GetKeyDown (KeyCode.U) && Time.time > timeToFire) {
			charging = true;
		}

		if (charging && damage <= maxDamage) {
			damage += Time.deltaTime * chargeSpeed;
		}
			
			
		if (Input.GetKeyUp (KeyCode.U)) {
			shoot ();
			charging = false;
			damage = 10;
		}
	}

	void shoot() {
		
		Vector2 firePointPosition = new Vector2 (firePoint.position.x, firePoint.position.y);
		RaycastHit2D hit = Physics2D.Raycast (firePointPosition, new Vector2 (direction, 0), 100, whatToHit);

		Effect ();

		Debug.DrawLine (firePointPosition, new Vector2 (direction * 100, firePointPosition.y));

		if (hit.collider != null) {
			Enemy enemy = hit.collider.gameObject.GetComponent<Enemy> ();
			if (enemy != null) {
				enemy.DamageEnemy ((int) damage);
			}
		}
	}

	void Effect() {
		Instantiate (bulletTrailPrefab, firePoint.position, firePoint.rotation);
	}
}
