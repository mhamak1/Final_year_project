using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RingY : MonoBehaviour {
	private const int ringNo = 2;

	// Use this for initialization
	void Start () {
		Destroy(gameObject, 10);
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate (30 * Time.deltaTime, 0, 0);
	}

	void OnTriggerEnter(Collider other){
		if (other.gameObject.CompareTag ("Player")) {
			other.GetComponent<accelerometer> ().checkRing (ringNo);
			DestroyObject(gameObject);
		}
	}
}
