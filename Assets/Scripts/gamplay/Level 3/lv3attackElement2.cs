using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lv3attackElement2 : MonoBehaviour {
	private float speed;
	// Use this for initialization
	void Start () {
		Destroy(gameObject, 5);
		speed = Random.Range (2.0f, 2.5f);
	}

	// Update is called once per frame
	void Update () {
			transform.Translate (0, speed*Time.deltaTime ,0);
	}

	void OnTriggerEnter(Collider other){
		if (other.gameObject.CompareTag ("Player")) {
			other.GetComponent<accelerometer> ().getDamage();
			DestroyObject(gameObject);
		}
	}
}
