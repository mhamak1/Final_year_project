using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lv2AttackElement : MonoBehaviour {
	public GameObject explo;
	private float speed;
	// Use this for initialization
	void Start () {
		Destroy(gameObject, 10);
		speed = Random.Range (0.8f, 1.0f);
	}

	// Update is called once per frame
	void Update () {

		transform.Translate (0, 0 ,-speed*Time.deltaTime);
	}

	void OnTriggerEnter(Collider other){
		if (other.gameObject.CompareTag ("Player")) {
			other.GetComponent<accelerometer> ().getDamage();
			DestroyObject(gameObject);
		}else if (other.gameObject.CompareTag ("ground")) {
			Instantiate (explo, new Vector3(gameObject.transform.position.x, 0.2f, gameObject.transform.position.z ), Quaternion.Euler (new Vector3 (0f, 0f, 0f)));
			DestroyObject(gameObject);
		}
	}
}
