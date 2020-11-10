using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class btnScript : MonoBehaviour {
	public GameObject pausePanel;
	public GameObject pauseBtn;

	public void returnGame(){	
		pausePanel.SetActive (false);
		pauseBtn.SetActive (true);
		Time.timeScale = 1;
	} 

	public void returnMenu(){
		Time.timeScale = 1;
		PlayerPrefs.DeleteKey ("playingStage");
		SceneManager.LoadScene ("level menu");
	}

	public void retryStage(){
		Time.timeScale = 1;
		if (PlayerPrefs.GetInt("playingStage") == 0) {
			SceneManager.LoadScene ("level 1");
		} else if (PlayerPrefs.GetInt("playingStage") == 1) {
			SceneManager.LoadScene ("level 2");
		} else if (PlayerPrefs.GetInt("playingStage") == 2) {
			SceneManager.LoadScene ("level 3");
		} else if (PlayerPrefs.GetInt("playingStage") == 3) {
			SceneManager.LoadScene ("level 4");
		} else if (PlayerPrefs.GetInt("playingStage") == 4) {
			SceneManager.LoadScene ("level 5");
		}
	}
}
