using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RingSpawner : MonoBehaviour {

	public GameObject player;
	public GameObject[] rings;
	public Vector3 spawnValues;
	public float spawnWait;
	public float spawnMaxWait;
	public float spawnMinWait;
	public int startWait;
	public bool stop;
	private int randRingNum;
	private int randRingType;

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
			randRingNum = Random.Range (1, 3);
			for (int i = 0; i < randRingNum; i++) {
				randRingType = Random.Range (0, 4);
				Vector3 spawnPos = new Vector3 (Random.Range (-spawnValues.x, spawnValues.x), 2, 4.5f);
				Instantiate (rings [randRingType], spawnPos + transform.TransformPoint(0, 0, 0), Quaternion.Euler(new Vector3(0, 90, 0)));
			}
			yield return new WaitForSeconds (spawnWait);

		}
	}
}
