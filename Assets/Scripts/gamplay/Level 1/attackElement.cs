using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class attackElement : MonoBehaviour {
	public GameObject explo;
	private float speed;
	// Use this for initialization
	void Start () {
		Destroy(gameObject, 10);
		speed = Random.Range (0.7f, 0.9f);
	}
	
	// Update is called once per frame
	void Update () {
		
		transform.Translate (0, -speed*Time.deltaTime , 0);
	}

	void OnTriggerEnter(Collider other){
		if (other.gameObject.CompareTag ("Player")) {
			other.GetComponent<accelerometer> ().getDamage();
			DestroyObject(gameObject);
		}else if (other.gameObject.CompareTag ("ground")) {
			Instantiate (explo, gameObject.transform.position, Quaternion.Euler (new Vector3 (0f, 0f, 0f)));
			DestroyObject(gameObject);
		}
	}
}
