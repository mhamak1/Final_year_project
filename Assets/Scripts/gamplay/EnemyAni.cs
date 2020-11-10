using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAni : MonoBehaviour {

	private string IDLE;
	private string ATTACK;
	private string DEATH;
	private bool waitReadyBool;

	void Start () {
		if (PlayerPrefs.GetInt ("playingStage") == 0) {
			IDLE = "Anim_Idle";
			ATTACK	= "Anim_Attack";
			DEATH	= "Anim_Death";
		} else if (PlayerPrefs.GetInt ("playingStage") == 1) {
			IDLE = "idle";
			ATTACK	= "attack01";
			DEATH	= "die";
		} else if (PlayerPrefs.GetInt ("playingStage") == 2) {
			IDLE = "Idle";
			ATTACK	= "Attack01";
			DEATH	= "Death";
		} else if (PlayerPrefs.GetInt ("playingStage") == 3) {
			IDLE = "Wait";
			ATTACK	= "Attack";
			DEATH	= "Dead";
		} else if (PlayerPrefs.GetInt ("playingStage") == 4) {
			IDLE = "Idle1";
			ATTACK	= "Attack";
			DEATH	= "Death2";
		} 
		waitReadyBool = true;
	}

	public void WaitAni (){
		if(waitReadyBool==true)
		GetComponent<Animation> ().Play (IDLE);
	}
		
	public void AttackAni (){
		GetComponent<Animation> ().Play (ATTACK);
		waitReadyBool = false;
		Invoke ("resetWRBool", 1.5f);
	}

	private void resetWRBool(){
		waitReadyBool = true;
	}

	public void DeathAni (){
		GetComponent<Animation> ().Play (DEATH);
	}

}
