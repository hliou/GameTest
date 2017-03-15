using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingEnemy : MonoBehaviour {

	public int speed;
	public Transform playerPosition;
	bool playerDetected = false;
	Rigidbody2D rb2d;

	void Start() {
		rb2d = GetComponent<Rigidbody2D> ();
	}

	// Update is called once per frame
	void Update () {
		Fly();
	}

	void Fly() {
		rb2d.velocity = new Vector2 (-speed, rb2d.velocity.y);

		if (playerDetected && playerPosition != null) {
			rb2d.velocity = new Vector3(-speed, -speed, transform.position.z);
		}
	}

	void OnTriggerEnter2D(Collider2D coll) {
		if (coll.gameObject.tag == "Player") {
			playerDetected = true;
		}
	}

	void OnCollisionEnter2D(Collision2D coll) {
		Destroy (this.gameObject);
	}

}
