using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetRingSpawner : MonoBehaviour {

	public GameObject[] rings;
	public GameObject player;

	private bool updateTarget = false;

	void Start () {
		//Debug.Log (Screen.width + " " + Screen.height);
	}

	void Update(){
		if (updateTarget == false) {

			float scaleValue = (((float)Screen.width / (float)Screen.height) - 1.5f);

			int randRing = Random.Range (0, 4);
			player.GetComponent<accelerometer> ().require [0] = randRing;
			Vector3 spawnPos = new Vector3 (-0.5f, 3.35f, 2.5f - scaleValue);
			Instantiate (rings [randRing], spawnPos, Quaternion.Euler(new Vector3(45, 80, 0)));

			int randRing2 = Random.Range (0, 4);
			player.GetComponent<accelerometer> ().require [1] = randRing2;
			Vector3 spawnPos2 = new Vector3 (0, 3.35f, 2.5f - scaleValue);
			Instantiate (rings [randRing2], spawnPos2, Quaternion.Euler(new Vector3(45, 90, 0)));

			int randRing3 = Random.Range (0, 4);
			player.GetComponent<accelerometer> ().require [2] = randRing3;
			Vector3 spawnPos3 = new Vector3 (0.5f, 3.35f, 2.5f - scaleValue);
			Instantiate (rings [randRing3], spawnPos3, Quaternion.Euler(new Vector3(45, 100, 0)));		
		
			updateTarget = true;
		}
	}
}
