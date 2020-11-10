using System.Collections;
using System.Collections.Generic;
using UnityEngine.Playables;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class levelMenuControl : MonoBehaviour {
	public Camera cam;
	public Image[] starImg;
	public GameObject[] levelBtn;
	public Image lockImg;
	private int currentLevel;

	void Start(){
		for (int i = 1; i < 5; i++) {
			levelBtn [i].SetActive (false);
		}
		lockImg.enabled = false;
		currentLevel = 0;
		showStarImg(PlayerPrefs.GetInt ("stage0Star"));
	}

	void Update () {
		
	}

	public void leftKey(){
		if (currentLevel != 0) {
			levelBtn [currentLevel].SetActive (false);
			currentLevel--;
			levelBtn [currentLevel].SetActive (true);
			int getStar = 0;
			if (currentLevel == 1) {
				cam.transform.position = new Vector3 (6f, 1f, 2f);
				getStar = PlayerPrefs.GetInt ("stage1Star");
			} else if (currentLevel == 2) {
				cam.transform.position = new Vector3 (13f, 1f, 2f);
				getStar = PlayerPrefs.GetInt ("stage2Star");
			} else if (currentLevel == 3) {
				cam.transform.position = new Vector3 (22f, 1f, 2f);
				getStar = PlayerPrefs.GetInt ("stage3Star");
			} else if (currentLevel == 0) {
				cam.transform.position = new Vector3 (0f, 1f, 2f);
				getStar = PlayerPrefs.GetInt ("stage0Star");
			}

			if (PlayerPrefs.GetInt ("stage") >= currentLevel) {
				lockImg.enabled = false;
			} else {
				lockImg.enabled = true;
			}

			showStarImg (getStar);
		}
	}

	public void rightKey(){
		if (currentLevel != 4) {
			levelBtn [currentLevel].SetActive (false);
			currentLevel++;
			levelBtn [currentLevel].SetActive (true);
			int getStar = 0 ;
			if (currentLevel == 1) {
				cam.transform.position = new Vector3 (6f, 1f, 2f);
				getStar = PlayerPrefs.GetInt ("stage1Star");
			} else if (currentLevel == 2) {
				cam.transform.position = new Vector3 (13f, 1f, 2f);
				getStar = PlayerPrefs.GetInt ("stage2Star");
			} else if (currentLevel == 3) {
				cam.transform.position = new Vector3 (22f, 1f, 2f);
				getStar = PlayerPrefs.GetInt ("stage3Star");
			} else if (currentLevel == 4) {
				cam.transform.position = new Vector3 (28f, 1f, 2f);
				getStar = PlayerPrefs.GetInt ("stage4Star");
			}

			if (PlayerPrefs.GetInt ("stage") >= currentLevel) {
				lockImg.enabled = false;
			} else {
				lockImg.enabled = true;
			}

			showStarImg (getStar);
		}
	}

	private void showStarImg(int getStar){
		if (getStar == 3) {
			starImg[0].enabled = true;
			starImg[1].enabled = true;
			starImg[2].enabled = true;
		} else if (getStar == 2) {
			starImg[0].enabled = true;
			starImg[1].enabled = true;
			starImg[2].enabled = false;
		} else if (getStar == 1) {
			starImg[0].enabled = true;
			starImg[1].enabled = false;
			starImg[2].enabled = false;
		} else {
			starImg[0].enabled = false;
			starImg[1].enabled = false;
			starImg[2].enabled = false;
		}
	}

	public void play(){
		if (PlayerPrefs.GetInt ("stage") >= currentLevel) {
			if (currentLevel == 0) {
				PlayerPrefs.SetInt ("playingStage", 0);
				SceneManager.LoadScene ("level 1");
			} else if (currentLevel == 1) {
				PlayerPrefs.SetInt ("playingStage", 1);
				SceneManager.LoadScene ("level 2");
			} else if (currentLevel == 2) {
				PlayerPrefs.SetInt ("playingStage", 2);
				SceneManager.LoadScene ("level 3");
			} else if (currentLevel == 3) {
				PlayerPrefs.SetInt ("playingStage", 3);
				SceneManager.LoadScene ("level 4");
			} else if (currentLevel == 4) {
				PlayerPrefs.SetInt ("playingStage", 4);
				SceneManager.LoadScene ("level 5");
			}
		}
	}

}
