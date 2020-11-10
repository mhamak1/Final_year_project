using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class showPetBtn : MonoBehaviour {
	public Text petDes;
	public GameObject pet1;
	public GameObject pet2;
	public GameObject pet3;
	public GameObject pet4;
	public GameObject pet5;
	public GameObject selectBtn;

	void Start(){
		petDes.text = " ";
		if (PlayerPrefs.GetInt ("pet") == 0) {
			pet1.SetActive (false);
			pet2.SetActive (false);
			pet3.SetActive (false);
			pet4.SetActive (false);
			pet5.SetActive (false);
		} else if (PlayerPrefs.GetInt ("pet") == 1) {
			pet1.SetActive (true);
			pet2.SetActive (false);
			pet3.SetActive (false);
			pet4.SetActive (false);
			pet5.SetActive (false);
		}else if (PlayerPrefs.GetInt ("pet") == 2) {
			pet1.SetActive (false);
			pet2.SetActive (true);
			pet3.SetActive (false);
			pet4.SetActive (false);
			pet5.SetActive (false);
		}else if (PlayerPrefs.GetInt ("pet") == 3) {
			pet1.SetActive (false);
			pet2.SetActive (false);
			pet3.SetActive (true);
			pet4.SetActive (false);
			pet5.SetActive (false);
		}else if (PlayerPrefs.GetInt ("pet") == 4) {
			pet1.SetActive (false);
			pet2.SetActive (false);
			pet3.SetActive (false);
			pet4.SetActive (true);
			pet5.SetActive (false);
		}else if (PlayerPrefs.GetInt ("pet") == 5) {
			pet1.SetActive (false);
			pet2.SetActive (false);
			pet3.SetActive (false);
			pet4.SetActive (false);
			pet5.SetActive (true);
		}
	}

	void Update () {
	}

	public void showEmpty(){
		petDes.text = " ";
		pet1.SetActive (false);
		pet2.SetActive (false);
		pet3.SetActive (false);
		pet4.SetActive (false);
		pet5.SetActive (false);
		selectBtn.GetComponent<selectBtn> ().changeBtnText (0);
	}

	public void showPet1(){
		petDes.text = "Effect: increase player moving speed ";
		pet1.SetActive (true);
		pet2.SetActive (false);
		pet3.SetActive (false);
		pet4.SetActive (false);
		pet5.SetActive (false);
		selectBtn.GetComponent<selectBtn> ().changeBtnText (1);
	}

	public void showPet2(){
		petDes.text = "Effect: enable double jump";
		pet1.SetActive (false);
		pet2.SetActive (true);
		pet3.SetActive (false);
		pet4.SetActive (false);
		pet5.SetActive (false);
		selectBtn.GetComponent<selectBtn> ().changeBtnText (2);
	}

	public void showPet3(){
		petDes.text = "Effect: ring will not be drop after player get damage ";
		pet1.SetActive (false);
		pet2.SetActive (false);
		pet3.SetActive (true);
		pet4.SetActive (false);
		pet5.SetActive (false);
		selectBtn.GetComponent<selectBtn> ().changeBtnText (3);
	}

	public void showPet4(){
		petDes.text = "Effect: increase player defense ";
		pet1.SetActive (false);
		pet2.SetActive (false);
		pet3.SetActive (false);
		pet4.SetActive (true);
		pet5.SetActive (false);
		selectBtn.GetComponent<selectBtn> ().changeBtnText (4);
	}

	public void showPet5(){
		petDes.text = "Effect: double receive coins ";
		pet1.SetActive (false);
		pet2.SetActive (false);
		pet3.SetActive (false);
		pet4.SetActive (false);
		pet5.SetActive (true);
		selectBtn.GetComponent<selectBtn> ().changeBtnText (5);
	}

}
