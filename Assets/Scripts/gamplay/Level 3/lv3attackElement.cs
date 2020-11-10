using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lv3attackElement : MonoBehaviour {
	private float speed;
	private bool updatePos;
	// Use this for initialization
	void Start () {
		updatePos = true;
		Destroy(gameObject, 5);
		speed = Random.Range (0.9f, 1.1f);
	}

	// Update is called once per frame
	void Update () {
		if(updatePos == true)
			transform.Translate (0, speed*Time.deltaTime ,0);
	}

	void OnTriggerEnter(Collider other){
		if (other.gameObject.CompareTag ("Player")) {
			other.GetComponent<accelerometer> ().getDamage();
			DestroyObject(gameObject);
		}else if (other.gameObject.CompareTag ("ground")) {
			Invoke ("stopUpdatePos", 0.1f);
		}
	}

	private void stopUpdatePos(){
		updatePos = false;
	}
}
