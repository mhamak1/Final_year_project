using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackSpawner : MonoBehaviour {
	public GameObject player;
	public GameObject enemy;
	public GameObject attack;
	public Vector3 spawnValues;
	public float spawnWait;
	public float spawnMaxWait;
	public float spawnMinWait;
	public int startWait;
	private int randAtt;
	private int side;

	// Use this for initialization
	void Start () {
		StartCoroutine (waitSpawner());
	}

	// Update is called once per frame
	void Update () {
		spawnWait = Random.Range (spawnMinWait, spawnMaxWait);
	}

	IEnumerator waitSpawner(){
		yield return new WaitForSeconds (startWait);

		while (player.GetComponent<accelerometer>().getGameOver() == false) {
			randAtt = Random.Range (3, 5);
			side = Random.Range (-1, 2);
			for (int i = 0; i < randAtt; i++) {
				Vector3 spawnPos;
				if (side == 1) {
					spawnPos = new Vector3 ((float)(4f - (1f * i)) , 5f, 4.5f);
				} else if (side == -1) {
					spawnPos = new Vector3 ((float)(-4f + (1f * i)) , 5f, 4.5f);
				} else {
					spawnPos = new Vector3 ((float)(0f - randAtt/2 + (1f * i)) , 5f, 4.5f);
				}
				Instantiate (attack, spawnPos + transform.TransformPoint (0f, 0f, 0f), Quaternion.Euler (new Vector3 (0f, 0f, 0f)));
			}
			enemy.GetComponent<EnemyAni>().AttackAni ();
			yield return new WaitForSeconds (spawnWait);
		}
	}
}
