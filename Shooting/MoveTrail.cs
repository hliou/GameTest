using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTrail : MonoBehaviour {

	public int moveSpeed = 230;
	public int direction;

	void Start() {
		direction = GameObject.Find ("pistol").GetComponent<Weapon> ().direction;
	}

	// Update is called once per frame
	void Update () {
		transform.Translate (Vector3.right * Time.deltaTime * moveSpeed * direction);

		Destroy (gameObject,(float) 0.2);
	}

	void OnCollisionEnter2D () {
		Destroy (gameObject);
	}
}
