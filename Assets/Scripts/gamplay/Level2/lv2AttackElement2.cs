using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lv2AttackElement2 : MonoBehaviour {

	private float speed;
	// Use this for initialization
	void Start () {
		Destroy(gameObject, 5);
		speed = Random.Range (1.5f, 2.0f);
	}

	// Update is called once per frame
	void Update () {

		transform.Translate (0, 0 ,-speed*Time.deltaTime);
	}

	void OnTriggerEnter(Collider other){
		if (other.gameObject.CompareTag ("Player")) {
			other.GetComponent<accelerometer> ().getDamage();
			DestroyObject(gameObject);
		}
	}
}
