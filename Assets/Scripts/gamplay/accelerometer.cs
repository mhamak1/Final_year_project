using System.Collections;
using System.Collections.Generic;
using UnityEngine.Playables;
using UnityEngine;
using UnityEngine.UI;

public class accelerometer : MonoBehaviour {

	public Camera gameCamera;
	public Camera skillCamera;
	public Camera playerCamera;
	public Camera monsterCamera;

	public GameObject enemy;

	public Image[] getImg; //img which show player which rings are collected
	public Image damagePan; //damage panel(red panel)
	private bool getDamageBool; //bool to check where player get damaged 
	public Image hpImg; //img of hp bar
	public Vector3 hpImgStartPos; // starting position of hp bar
	public GameObject gameCanvas; 
	public Image readyImg;
	public Image startImg;

	public Image skillTime; //skill time image
	public GameObject lineEffect; //line effect
	public GameObject chargeEffect; //player charging effect	public GameObject rotateCanvas;

	public GameObject extenCanvas;
	public Image extenImg; // a holdup
	public Image[] countTimeImg; // image for counting time
	public Image fullyChargeImg;
	private int counter; //counter for counting time

	public int[] require; //which rings are required to collect (R=0, G=1, Y=2, B=3)
	public bool[] collected; //whether player already collect required object
	private bool gameover;
	private bool extenTime; // if it is time to ask player to exten
	private bool enemyWait;

	private float maxHp; //max hp of player 
	private float currentHp; //current hp value
	private float attackDamage;

	private int direction = 0; //0 <-looking to camera, 2 <- left, 1 <- right
	private bool onGround; //check whether player on ground;
	private Rigidbody rb;

	public GameObject skillAni;

	public GameObject VictoryCanvas;
	public GameObject DefectCanvas;
	public GameObject endGameCanvas; //canvas with return and retry button

	public GameObject pausePanel;

	public Image[] starImg;

	private float playerSpeed;

	private bool doubleJump;

	public Text showGetCoins;

	public AudioClip rAudio;
	public AudioClip damageAudio;
	public AudioClip chargeAudio;
	public AudioClip skillAudio;
	public AudioClip victoryAudio;
	public AudioClip loseAudio;

	AudioSource audioSource;

	public AudioSource bgm;
	// Use this for initialization
	void Start () {
		gameover = false;
		extenTime = false;

		gameCamera.enabled = true;
		skillCamera.enabled = false;
		playerCamera.enabled = false;
		monsterCamera.enabled = false;

		direction = 0;

		onGround = true;

		rb = GetComponent<Rigidbody> ();

		require = new int[3];
		collected = new bool[3]{false, false, false};

		getImg[0].enabled = false;
		getImg[1].enabled = false;
		getImg[2].enabled = false;
		damagePan.enabled = false;
		getDamageBool = false;
		skillTime.enabled = false;
		lineEffect.SetActive (false);
		chargeEffect.SetActive (false);
		extenCanvas.SetActive (false);

		hpImgStartPos = hpImg.transform.localPosition;

		maxHp = 100;
		currentHp = maxHp;
		attackDamage = 20;

		for (int i = 0; i < 10; i++) {
			countTimeImg [i].enabled = false;
		}

		fullyChargeImg.enabled = false;

		VictoryCanvas.SetActive (false);
		DefectCanvas.SetActive (false);
		endGameCanvas.SetActive (false);

		enemyWait = true;

		starImg [0].enabled = false;
		starImg [1].enabled = false;
		starImg [2].enabled = false;

		pausePanel.SetActive (false);

		startImg.enabled = false;
		Invoke ("showStartImg", 1);

		if (PlayerPrefs.GetInt ("pet") == 1) {
			playerSpeed = 2.5f;
		} else {
			playerSpeed = 1.5f;
		}

		doubleJump = true;

		Input.gyro.enabled = true;

		audioSource = GetComponent<AudioSource>();

	}

	private void showStartImg(){
		readyImg.enabled = false;
		startImg.enabled = true;
		Invoke ("closeStartImg", 1);
	}

	private void closeStartImg(){
		startImg.enabled = false;
	}
		
	
	// Update is called once per frame
	void Update () {
		float accX = Input.acceleration.x;
		float accY = Input.acceleration.y;
		float accZ = Input.acceleration.z;

		if (gameover == false) {
			if (((accX >= 0.3 & accY >= -0.8 & accZ >= -0.35)
				&(accX<=0.9 & accZ <= 0.3)
				& Input.gyro.rotationRateUnbiased.x < 0.4f
				& Input.gyro.rotationRateUnbiased.y < 0.4f
				& Input.gyro.rotationRateUnbiased.z < 0.3f)
				|| Input.GetKey (KeyCode.RightArrow)) {
				if (direction == 0) {
					transform.Rotate (0, -90, 0);
				} else if (direction == 2) {
					transform.Rotate (0, -180, 0);
				}
				direction = 1;
				if (transform.position.x < 4) {
					transform.Translate (0, 0, playerSpeed * Time.deltaTime);
				}
				GetComponent<Animation> ().Play ("Walk");
			} else if (((accX <= -0.3 & accY >= -0.8 & accZ >= -0.35)
				&(accX>=-0.9 & accZ <= 0.3)
				& Input.gyro.rotationRateUnbiased.x < 0.4f
				& Input.gyro.rotationRateUnbiased.y < 0.4f
				& Input.gyro.rotationRateUnbiased.z < 0.3f)
				|| Input.GetKey (KeyCode.LeftArrow)) {		
				if (direction == 0) {
					transform.Rotate (0, 90, 0);
				} else if (direction == 1) {
					transform.Rotate (0, 180, 0);
				}
				direction = 2;
				if (transform.position.x > -4) {
					transform.Translate (0, 0, playerSpeed * Time.deltaTime);
				}
				GetComponent<Animation> ().Play ("Walk");
			} else {
				if (direction == 1) {
					transform.Rotate (0, 90, 0);
				} else if (direction == 2) {
					transform.Rotate (0, -90, 0);
				}
				direction = 0;
				GetComponent<Animation> ().Play ("Wait");
			}

			if ((Input.GetKeyDown (KeyCode.UpArrow) || (Input.touchCount > 0 && Input.GetTouch (0).phase == TouchPhase.Began && (((float)(Screen.height)) / ((float)(Input.GetTouch (0).position.y))) >= 1.3)) ) {
				if (onGround == true) {
					rb.velocity = new Vector3 (0f, 5.5f, 0f);
					onGround = false;
				} else if(PlayerPrefs.GetInt("pet") == 2 & doubleJump == true) {
					rb.velocity = new Vector3 (0f, 4f, 0f);
					doubleJump = false;
				}
			}
		} else if(extenTime == true){
			GetComponent<Animation> ().Play ("Wait");
		}

		if (enemyWait == true) {
			enemy.GetComponent<EnemyAni> ().WaitAni ();
		}
			
		Debug.Log (Input.gyro.rotationRateUnbiased);
	}

	public bool getGameOver(){
		return gameover;
	}

	void OnCollisionEnter(Collision other){
		if (other.gameObject.CompareTag ("ground")) {
			onGround = true;
			doubleJump = true;
		}
	}

	public void checkRing(int r){
		if (gameover == false) {
			for (int i = 0; i < require.Length; i++) {
				if (require [i] == r && collected [i] == false) {
					collected [i] = true;
					getImg [i].enabled = true;
					audioSource.PlayOneShot(rAudio, 1F);
					break;
				}
			}
			if (collected [0] == true && collected [1] == true && collected [2] == true) {
				gameover = true;
				skillTime.enabled = true;
				lineEffect.SetActive (true);
				Invoke ("enterSkillTimeScene", 2f);
			}
		}
	}

	public void enterSkillTimeScene(){
		gameCanvas.SetActive (false);
		lineEffect.SetActive (false);
		gameCamera.enabled = false;
		skillCamera.enabled = true;
		transform.position = new Vector3 (1, 0, 3);
		transform.rotation = Quaternion.Euler (0, -60, 0);
		enemy.transform.position = new Vector3 (-2, 2, 4);
		enemy.transform.rotation = Quaternion.Euler (20, 130, 0);
		chargeEffect.SetActive (true);
		extenCanvas.SetActive (true);
		extenTime = true;
		StartCoroutine (countForExten ());
	}

	IEnumerator countForExten(){
		yield return new WaitForSeconds (0f);
		while (counter<10) {
			float accX = Input.acceleration.x;
			float accY = Input.acceleration.y;
			float accZ = Input.acceleration.z;
			if ((accX <= 0.2 & accX >= -0.2 & accY >= -0.2 & accY <= 0.2 & accZ >= 0.8)
				|| Input.GetKey (KeyCode.UpArrow)) {
				if (counter < 9) {
				    countTimeImg [counter].enabled = true;
					audioSource.PlayOneShot(chargeAudio, 1F);
					counter++;
				} else if (counter == 9) {
					countTimeImg [counter].enabled = true;
					counter++;
					lineEffect.transform.position = new Vector3 (0f, 2f, 1.5f);
					fullyChargeImg.enabled = true;
					Invoke ("showAttackAni", 2f);
				}
			}
			yield return new WaitForSeconds (1f);
		}
	}



	private void showAttackAni(){
		extenTime = false;
		extenCanvas.SetActive (false);
		chargeEffect.transform.position = new Vector3 (1f, -1f, 3f);
		skillCamera.enabled = false;
		playerCamera.enabled = true;
		GetComponent<Animation> ().Play ("Attack");
		Invoke ("showSkillAni", 1f);
	}

	private void showSkillAni(){
		playerCamera.enabled = false;
		monsterCamera.enabled = true;
		Instantiate (skillAni, new Vector3(-1, 2, 3), Quaternion.Euler(0, 0, 0));
		enemyWait = false;
		audioSource.PlayOneShot(skillAudio, 1F);
		Invoke ("showEnemyDeathAni", 0.5f);
	}

	private void showEnemyDeathAni(){
		enemy.GetComponent<EnemyAni>().DeathAni ();
		Invoke ("showVictory", 0.5f);
	}

	private void showVictory(){
		bgm.Stop ();
		audioSource.PlayOneShot(victoryAudio, 1F);
		VictoryCanvas.SetActive (true);
		endGameCanvas.SetActive (true);
		int getStar = 0;
		if (currentHp / maxHp >= 0.8) {
			starImg [0].enabled = true;
			starImg [1].enabled = true;
			starImg [2].enabled = true;
			getStar = 3;
		} else if (currentHp / maxHp >= 0.5) {
			starImg [0].enabled = true;
			starImg [1].enabled = true;
			getStar = 2;
		} else {
			starImg [0].enabled = true;
			getStar = 1;
		}

		if (PlayerPrefs.GetInt ("stage") == PlayerPrefs.GetInt ("playingStage")) {
			PlayerPrefs.SetInt ("stage", PlayerPrefs.GetInt ("stage") + 1);
		}

		if (PlayerPrefs.GetInt ("playingStage") == 0) {
			if (PlayerPrefs.GetInt ("pet") == 5) {
				showGetCoins.text = "+ 200";
				PlayerPrefs.SetInt ("coins", PlayerPrefs.GetInt ("coins") + 200);
			} else {
				showGetCoins.text = "+ 100";
				PlayerPrefs.SetInt ("coins", PlayerPrefs.GetInt ("coins") + 100);
			}
			if (PlayerPrefs.GetInt ("stage0Star") < getStar) {
				PlayerPrefs.SetInt ("stage0Star", getStar);
			}
		} else if (PlayerPrefs.GetInt ("playingStage") == 1) {
			if (PlayerPrefs.GetInt ("pet") == 5) {
				showGetCoins.text = "+ 400";
				PlayerPrefs.SetInt ("coins", PlayerPrefs.GetInt ("coins") + 400);
			} else {
				showGetCoins.text = "+ 200";
				PlayerPrefs.SetInt ("coins", PlayerPrefs.GetInt ("coins") + 200);
			}
			if (PlayerPrefs.GetInt ("stage1Star") < getStar) {
				PlayerPrefs.SetInt ("stage1Star", getStar);
			}
		} else if (PlayerPrefs.GetInt ("playingStage") == 2) {
			if (PlayerPrefs.GetInt ("pet") == 5) {
				showGetCoins.text = "+ 800";
				PlayerPrefs.SetInt ("coins", PlayerPrefs.GetInt ("coins") + 800);
			} else {
				showGetCoins.text = "+ 400";
				PlayerPrefs.SetInt ("coins", PlayerPrefs.GetInt ("coins") + 400);
			}
			if (PlayerPrefs.GetInt ("stage2Star") < getStar) {
				PlayerPrefs.SetInt ("stage2Star", getStar);
			}
		} else if (PlayerPrefs.GetInt ("playingStage") == 3) {
			if (PlayerPrefs.GetInt ("pet") == 5) {
				showGetCoins.text = "+ 1600";
				PlayerPrefs.SetInt ("coins", PlayerPrefs.GetInt ("coins") + 1600);
			} else {
				showGetCoins.text = "+ 800";
				PlayerPrefs.SetInt ("coins", PlayerPrefs.GetInt ("coins") + 800);
			}
			if (PlayerPrefs.GetInt ("stage3Star") < getStar) {
				PlayerPrefs.SetInt ("stage3Star", getStar);
			}
		} else if (PlayerPrefs.GetInt ("playingStage") == 4) {
			if (PlayerPrefs.GetInt ("pet") == 5) {
				showGetCoins.text = "+ 3200";
				PlayerPrefs.SetInt ("coins", PlayerPrefs.GetInt ("coins") + 3200);
			} else {
				showGetCoins.text = "+ 1600";
				PlayerPrefs.SetInt ("coins", PlayerPrefs.GetInt ("coins") + 1600);
			}
			if (PlayerPrefs.GetInt ("stage4Star") < getStar) {
				PlayerPrefs.SetInt ("stage4Star", getStar);
			}
		}
			
	}

	public void getDamage(){
		if(gameover == false && getDamageBool == false){
			damagePan.enabled = true;
			getDamageBool = true;
			audioSource.PlayOneShot(damageAudio, 1F);
			if (PlayerPrefs.GetInt ("pet") == 4) {
				currentHp = currentHp - (attackDamage/2);
			} else {
				currentHp = currentHp - attackDamage;
			}

			if (currentHp < 0) {
				currentHp = 0;
			}

			hpImg.transform.localPosition = new Vector3 ( hpImgStartPos.x + (float)(200) * ((float)(currentHp) / (float)(maxHp)) - 200.0f, hpImgStartPos.y + 0f, hpImgStartPos.z + 0f);
			if (PlayerPrefs.GetInt ("pet") != 3) {
				for (int i = 0; i < require.Length; i++) {
					if (collected [i] == true) {
						collected [i] = false;
						getImg [i].enabled = false;
						break;
					}
				}
			}
			Invoke ("resetDamagePan", 1f); //run the function with 1 sec delay
			if (currentHp <= 0) {
				gameover = true;
				if (direction == 1) {
					transform.Rotate (0, 90, 0);
				} else if (direction == 2) {
					transform.Rotate (0, -90, 0);
				}
				direction = 0;
				bgm.Stop ();
				Invoke ("playGameOverAni", 2f);
			}
		}
	}

	private void resetDamagePan(){
		getDamageBool = false;
		damagePan.enabled = false;
	}

	private void playGameOverAni(){
		GetComponent<Animation> ().Play ("Dead");
		Invoke ("showDefect", 1f);

	}

	private void showDefect(){
		audioSource.PlayOneShot(loseAudio, 1F);
		DefectCanvas.SetActive (true);
		endGameCanvas.SetActive (true);
	}
		
}
