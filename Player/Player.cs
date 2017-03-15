using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {


	[System.Serializable]
	public class PlayerStats {
		public int maxHealth = 100;

		private int _currHealth;
		public int currHealth {
			get { return _currHealth; }
			set { _currHealth = Mathf.Clamp(value, 0, maxHealth);}
		}


		public void Init() {
			currHealth = maxHealth;
		}
	}

	public PlayerStats stats = new PlayerStats();

	public int fallBoundary = -20;

	[SerializeField]
	private StatusIndicator statusIndicatorPrefab; 

	private StatusIndicator statusIndicator;

	void Start() {
		stats.Init ();

		statusIndicator = Instantiate(statusIndicatorPrefab, new Vector3(360, 154, 0), new Quaternion (0, 0, 0, 0));

		if (statusIndicator == null) {
			Debug.Log ("rip");
		} else {
			
			statusIndicator.SetHealth (stats.currHealth, stats.maxHealth);

		}
	}

	void Update() {
			
		if (transform.position.y <= fallBoundary) {
			DamagePlayer (99999);
		}
	}

	public void DamagePlayer (int damage) {
		stats.currHealth -= damage;
		statusIndicator.SetHealth (stats.currHealth, stats.maxHealth);

		if (stats.currHealth <= 0) {
			GameMaster.killPlayer (this);
			Destroy (statusIndicator.gameObject);
		}

	}
}
