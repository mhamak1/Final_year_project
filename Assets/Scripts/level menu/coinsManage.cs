using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class coinsManage : MonoBehaviour {
	public Text showCoins; 
	// Use this for initialization
	void Start () {
		showCoins.text = PlayerPrefs.GetInt ("coins").ToString();
	}
}
