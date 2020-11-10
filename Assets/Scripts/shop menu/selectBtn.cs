using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class selectBtn : MonoBehaviour {
	public Text text1;
	public Text coins;
	public Image[] lockImg;
	private int selectedbtn;
	private int[] price;

	void Start(){
		coins.text = PlayerPrefs.GetInt ("coins").ToString ();

		if (PlayerPrefs.GetInt ("enablePet1") == 1) {
			lockImg [0].enabled = false;
		}
		if (PlayerPrefs.GetInt ("enablePet2") == 1) {
			lockImg [1].enabled = false;
		}
		if (PlayerPrefs.GetInt ("enablePet3") == 1) {
			lockImg [2].enabled = false;
		}
		if (PlayerPrefs.GetInt ("enablePet4") == 1) {
			lockImg [3].enabled = false;
		}
		if (PlayerPrefs.GetInt ("enablePet5") == 1) {
			lockImg [4].enabled = false;
		}

		price = new int[6];
		price [0] = 0;
		price [1] = 1000;
		price [2] = 2000;
		price [3] = 3000;
		price [4] = 4000;
		price [5] = 5000;
	}

	public void changeBtnText(int i){
		if (PlayerPrefs.GetInt ("pet") == i) {
			text1.text = "SELECTED";
		} else if (i == 0) {
			text1.text = "select";
		} else if (i == 1 & PlayerPrefs.GetInt ("enablePet1") == 1) {
			text1.text = "select";
		} else if (i == 2 & PlayerPrefs.GetInt ("enablePet2") == 1) {
			text1.text = "select";
		} else if (i == 3 & PlayerPrefs.GetInt ("enablePet3") == 1) {
			text1.text = "select";
		} else if (i == 4 & PlayerPrefs.GetInt ("enablePet4") == 1) {
			text1.text = "select";
		} else if (i == 5 & PlayerPrefs.GetInt ("enablePet5") == 1) {
			text1.text = "select";
		} else {
			text1.text = price [i].ToString();
		}
		selectedbtn = i;
	}

	public void onClickBtn(){
		Debug.Log (selectedbtn);
		if (selectedbtn != PlayerPrefs.GetInt ("pet")) {
			if (selectedbtn == 0) {
				PlayerPrefs.SetInt ("pet", 0);
				text1.text = "SELECTED";
			} else if (selectedbtn == 1 & PlayerPrefs.GetInt ("enablePet1") == 1) {
				PlayerPrefs.SetInt ("pet", 1);
				text1.text = "SELECTED";
			} else if (selectedbtn == 2 & PlayerPrefs.GetInt ("enablePet2") == 1) {
				PlayerPrefs.SetInt ("pet", 2);
				text1.text = "SELECTED";
			} else if (selectedbtn == 3 & PlayerPrefs.GetInt ("enablePet3") == 1) {
				PlayerPrefs.SetInt ("pet", 3);
				text1.text = "SELECTED";
			} else if (selectedbtn == 4 & PlayerPrefs.GetInt ("enablePet4") == 1) {
				PlayerPrefs.SetInt ("pet", 4);
				text1.text = "SELECTED";
			} else if (selectedbtn == 5 & PlayerPrefs.GetInt ("enablePet5") == 1) {
				PlayerPrefs.SetInt ("pet", 5);
				text1.text = "SELECTED";
			} else {
				if (PlayerPrefs.GetInt ("coins") >= price [selectedbtn]) {
					if (selectedbtn == 1 ) {
						PlayerPrefs.SetInt ("enablePet1", 1);
						PlayerPrefs.SetInt ("pet", 1);
					} else if (selectedbtn == 2 ) {
						PlayerPrefs.SetInt ("enablePet2", 1);
						PlayerPrefs.SetInt ("pet", 2);
					} else if (selectedbtn == 3 ) {
						PlayerPrefs.SetInt ("enablePet3", 1);
						PlayerPrefs.SetInt ("pet", 3);
					} else if (selectedbtn == 4 ) {
						PlayerPrefs.SetInt ("enablePet4", 1);
						PlayerPrefs.SetInt ("pet", 4);
					} else if (selectedbtn == 5 ) {
						PlayerPrefs.SetInt ("enablePet5", 1);
						PlayerPrefs.SetInt ("pet", 5);
					}
					lockImg [selectedbtn-1].enabled = false;
					PlayerPrefs.SetInt ("coins", PlayerPrefs.GetInt ("coins") - price [selectedbtn]);
					text1.text = "SELECTED";
					coins.text = PlayerPrefs.GetInt ("coins").ToString ();
				}
			}
		}
	}

	public void loadLevelMenu(){
		SceneManager.LoadScene("level menu");
	}
}
