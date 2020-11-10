using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lv5AttackElement : MonoBehaviour {
	private float speed;
	private float speedOnGround;
	private int leftRight; //0 = left, 1 = right
	private bool falling;
	private float randExploTime;
	public GameObject explo;
	// Use this for initialization
	void Start () {
		falling = true;
		Destroy(gameObject, 15);
		speed = Random.Range (1.0f, 1.3f);
		speedOnGround = Random.Range (1.5f, 2.0f);
		leftRight = Random.Range (0, 2);
		randExploTime = Random.Range (1f, 3f);
	}

	// Update is called once per frame
	void Update () {
		if (falling == true) {
			transform.Translate (0, -speed * Time.deltaTime, 0);
		} else {
			transform.Translate (-speedOnGround * Time.deltaTime, 0, 0);
		}
			
	}

	void OnTriggerEnter(Collider other){
		if (other.gameObject.CompareTag ("Player")) {
			other.GetComponent<accelerometer> ().getDamage ();
			DestroyObject (gameObject);
		} else if (other.gameObject.CompareTag ("ground") & falling == true) {
			Debug.Log ("onGround");
			if (leftRight == 0) {
				
				transform.Rotate (0f, 90f, 0f);
			} else {
				transform.Rotate (0f, -90f, 0f);
			}
			falling = false;
			Invoke ("randExplo", randExploTime);
		}
	}
		
	private void randExplo(){
		Instantiate (explo, gameObject.transform.position, Quaternion.Euler (new Vector3 (0f, 0f, 0f)));
		Destroy (gameObject);
	}
}
