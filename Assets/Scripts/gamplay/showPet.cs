using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class showPet : MonoBehaviour {
	public GameObject[] pet;
	// Use this for initialization
	void Start () {
		for (int i = 0; i < 5; i++) {
			if (i != PlayerPrefs.GetInt ("pet")-1) {
				Destroy (pet [i]);
			}
		}
	}

}
