using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lv4attackElementExplo : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Destroy(gameObject, 2);
	}
	
	// Update is called once per frame
	void OnTriggerEnter(Collider other){
		if (other.gameObject.CompareTag ("Player")) {
			other.GetComponent<accelerometer> ().getDamage();
		}
	}
}
