using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotation : MonoBehaviour {

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
			DestroyObject(gameObject);
		}
	}

}
