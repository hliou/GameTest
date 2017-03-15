using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMaster : MonoBehaviour {

	public static GameMaster gm;

	private static int _remainingLives = 3;
	public static int RemainingLives {
		get { return _remainingLives; }	
	}
	void Start () {
		if (gm == null) {
			gm = GameObject.FindGameObjectWithTag ("GM").GetComponent<GameMaster>();
		}
	}

	public Transform playerPrefab;
	public Transform spawnPoint;
	public int spawnDelay = 2;

	public IEnumerator EndGame() {
		Debug.Log ("Game over");
		float fadeTime = GameObject.Find ("_GM").GetComponent<Fading> ().beginFade (1);
		yield return new WaitForSeconds (fadeTime);
		SceneManager.LoadScene ("GameOver", LoadSceneMode.Single);		
	}
	public IEnumerator respawnPlayer () {
		Debug.Log ("TODO: spawn sound and animation");
		yield return new WaitForSeconds (spawnDelay);
		Instantiate (playerPrefab, spawnPoint.position, spawnPoint.rotation);
	}

	public static void killPlayer (Player player) {
		Destroy (player.gameObject);
		_remainingLives -= 1;

		if (_remainingLives <= 0) {
			gm.StartCoroutine (gm.EndGame ());
		} else {
			gm.StartCoroutine (gm.respawnPlayer ());
		}
	}

	public static void killEnemy (Enemy enemy) {
		Destroy (enemy.gameObject);
	}
}
