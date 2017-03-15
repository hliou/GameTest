using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour {


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnColliderEnter2D(Collider2D coll) {
		if (coll.gameObject.tag == "Bullet") {
			Destroy (coll.gameObject);
		}
	}
}
