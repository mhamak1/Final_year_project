using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lv4attackelement : MonoBehaviour {

	private float speed;
	public GameObject explo;
	// Use this for initialization
	void Start () {
		Destroy(gameObject, 10);
		speed = Random.Range (1.2f, 1.3f);
	}

	// Update is called once per frame
	void Update () {

		transform.Translate (0, 0 ,-speed*Time.deltaTime);
	}

	void OnTriggerEnter(Collider other){
		if (other.gameObject.CompareTag ("Player")) {
			other.GetComponent<accelerometer> ().getDamage ();
			DestroyObject (gameObject);
		} else if (other.gameObject.CompareTag ("ground")) {
			Instantiate (explo, gameObject.transform.position, Quaternion.Euler (new Vector3 (0f, 0f, 0f)));
			DestroyObject(gameObject);
		}
	}
}
