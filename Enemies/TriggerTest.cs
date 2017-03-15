using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerTest : MonoBehaviour {

	public Enemy enemyPrefab;
	public Transform spawnPoint;

	private Enemy enemy;

	void OnTriggerEnter2D (Collider2D coll) {
		if (coll.gameObject.tag == "Player") {
			enemy = Instantiate (enemyPrefab, spawnPoint.position, spawnPoint.rotation);
			Destroy (this.gameObject);
		}
	}
}
