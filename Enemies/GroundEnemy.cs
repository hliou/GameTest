using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundEnemy : MonoBehaviour {

	public bool isLeft = true;
	public int speed;

	Rigidbody2D rb2d;

	void Start() {
		rb2d = GetComponent<Rigidbody2D> ();
	}

	// Update is called once per frame
	void Update () {
		GoToPlayer();
	}

	void GoToPlayer() {
		if (isLeft) {
			rb2d.velocity = new Vector2 (-speed, rb2d.velocity.y);
		} else {
			rb2d.velocity = new Vector2 (speed, rb2d.velocity.y);
		}
	}

	void OnCollisionEnter2D(Collision2D coll) {
		if (coll.gameObject.tag == "Wall") {
			isLeft = !isLeft;
		}
	}
}
