﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class startScreenAni : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		GetComponent<Animation> ().Play ("Wait");
	}
}
