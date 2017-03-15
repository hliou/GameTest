using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

	[System.Serializable]
	public class EnemyStats {
		public int maxHealth = 100;

		private int _currHealth;
		public int currHealth {
			get {return _currHealth;}
			set {_currHealth = Mathf.Clamp(value, 0, maxHealth);}
		}

		public int damage = 10;

		public void init() {
			currHealth = maxHealth;
		}
	}

	public EnemyStats stats = new EnemyStats();

	[Header("Optional: ")]
	[SerializeField]
	private StatusIndicator statusIndicator;

	void Start() {
		stats.init();

		if (statusIndicator != null) {
			statusIndicator.SetHealth (stats.currHealth, stats.maxHealth);
		}
	}

	public int fallBoundary = -20;


	public void DamageEnemy (int damage) {
		stats.currHealth -= damage;
		if (stats.currHealth <= 0) {
			GameMaster.killEnemy (this);
		}

		if (statusIndicator != null) {
			statusIndicator.SetHealth (stats.currHealth, stats.maxHealth);
		}
	}

	void OnCollisionEnter2D(Collision2D coll) {
		Player _player = coll.collider.GetComponent<Player> ();
		if (_player != null) {
			_player.DamagePlayer (stats.damage);
			DamageEnemy (9999999);
		}
	}
}

