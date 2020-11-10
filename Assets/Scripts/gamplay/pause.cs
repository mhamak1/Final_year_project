using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pause : MonoBehaviour {

	public bool paused;
	public GameObject pausePanel;

	// Use this for initialization
	void Start () {
		paused = false;
	//	pausePanel.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void pauseFunction(){
		paused = true;

		if (paused) {
			Time.timeScale = 0;
			pausePanel.SetActive (true);
			gameObject.SetActive(false);
		}
	} 
}
