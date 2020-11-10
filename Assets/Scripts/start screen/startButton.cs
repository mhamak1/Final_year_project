using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class startButton : MonoBehaviour {
	public void startBtn(){
		if (PlayerPrefs.HasKey ("stage") != true) {
			PlayerPrefs.SetInt ("stage", 0);
			PlayerPrefs.SetInt ("stage0Star", 0);
			PlayerPrefs.SetInt ("stage1Star", 0);
			PlayerPrefs.SetInt ("stage2Star", 0);
			PlayerPrefs.SetInt ("stage3Star", 0);
			PlayerPrefs.SetInt ("stage4Star", 0);
			PlayerPrefs.SetInt ("coins", 0);
			PlayerPrefs.SetInt ("pet", 0);
			PlayerPrefs.SetInt ("enablePet1", 0);
			PlayerPrefs.SetInt ("enablePet2", 0);
			PlayerPrefs.SetInt ("enablePet3", 0);
			PlayerPrefs.SetInt ("enablePet4", 0);
			PlayerPrefs.SetInt ("enablePet5", 0);
		}
	
		SceneManager.LoadScene("level menu");
	} 
}
