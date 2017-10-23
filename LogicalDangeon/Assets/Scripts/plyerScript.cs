using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class plyerScript : MonoBehaviour {
	public float moveSpeed;
	public float turnSpeed;
	public float vertical;
	public bool isJump;

	private Rigidbody rb;
	private float movementInputValue;
	private float turnInputValue;

	public float time = 300.0f;
	public int itemnum = 15;
	public int correctnum = 4;
	public int wrongnum = 4;
	public Text timeLabel;
	public Text itemLabel;
	public Text guideLabel;

	public Vector3 startpos;
	public Vector3 startrotate;

	public GameObject whole;
	public GameObject preload;
	public bool isWhole2;

	managerScript managerPara;
	public GameObject manager;

	soundScript soundPara;
	public GameObject soundObject;

	void Awake(){
		rb = GetComponent<Rigidbody>();
		moveSpeed = 30.0f;
		turnSpeed = 50.0f;

		manager = GameObject.Find("Manager");
		managerPara = manager.GetComponent<managerScript>();

		soundObject = GameObject.Find("SoundObject");
		soundPara = soundObject.GetComponent<soundScript> ();
	}

	void Start(){
		transform.position = managerPara.playerPos;

		time = PlayerPrefs.GetFloat("timeKey", 300.0f);
		itemnum = PlayerPrefs.GetInt("itemKey", 15);
		correctnum = PlayerPrefs.GetInt("correctKey", 4);
		wrongnum = PlayerPrefs.GetInt("wrongKey", 4);
	}

	void Update () {
		movementInputValue = Input.GetAxis("Vertical");
		turnInputValue = Input.GetAxis("Horizontal");

		time -= 1.0f*Time.deltaTime;
		int guidesum = correctnum + wrongnum;

		timeLabel.text = "time:" + time.ToString();
		itemLabel.text = "QuizItem:" + itemnum.ToString();
		guideLabel.text = "GuideItem:" + guidesum.ToString ();

		if(time <= 0){
			PlayerPrefs.DeleteAll();
			managerPara.playerPos = managerPara.defaultPos;
			managerPara.soundTime = 0.0f;
			Destroy(whole);
			SceneManager.LoadScene ("Game Over");
		}
	}
		
	void FixedUpdate(){
		Move();
		Turn();
		/*
		if(isJump == true){
			vertical = 10.0f;
			gameObject.GetComponent<Rigidbody> ().velocity = new Vector3(0, vertical, 0);
			if(transform.position.y > 14){
				isJump = false;
			}
		}
		if(isJump == false){
			vertical = -15.0f;
			gameObject.GetComponent<Rigidbody>().velocity = new Vector3(0, vertical, 0);
			if(transform.position.y == 0){
				vertical = 0.0f;
			}
			if(Input.GetButtonDown("Jump")){
				isJump = true;
			}
		}
		*/
	}
		
	void OnTriggerEnter(Collider goal){
		if(goal.gameObject.tag == "Goal"){
			PlayerPrefs.DeleteAll();
			managerPara.playerPos = managerPara.defaultPos;
			managerPara.time = time;
			Destroy(whole);
			SceneManager.LoadScene ("Goal");
		}
	}

	void OnCollisionEnter(Collision col) {
		float angleDir = transform.eulerAngles.z * (Mathf.PI / 180.0f);
		Vector3 dir = new Vector3 (Mathf.Cos (angleDir), Mathf.Sin (angleDir), 0.0f);
		Vector3 dire = transform.forward * Mathf.Cos(angleDir) ;
		// 自身の向きに移動
		transform.position -= dire;

		if(col.gameObject.tag == "item"){
			Debug.Log ("Collision!");
			Destroy (col.gameObject);
			itemnum--;

			PlayerPrefs.SetFloat("timeKey", time);
			PlayerPrefs.SetInt("itemKey", itemnum);
			PlayerPrefs.SetInt("correctKey", correctnum);
			PlayerPrefs.SetInt("wrongKey", wrongnum);
			PlayerPrefs.Save();

			managerPara.playerPos = this.gameObject.transform.position;
			managerPara.soundTime = soundPara.audioSource.time;
			SceneManager.LoadScene("quiz");
		} 

		if(col.gameObject.tag == "wrong"){
			Destroy (col.gameObject);
			wrongnum--;

			PlayerPrefs.SetFloat("timeKey", time);
			PlayerPrefs.SetInt("itemKey", itemnum);
			PlayerPrefs.SetInt("correctKey", correctnum);
			PlayerPrefs.SetInt("wrongKey", wrongnum);
			PlayerPrefs.Save();

			managerPara.playerPos = this.gameObject.transform.position;
			managerPara.soundTime = soundPara.audioSource.time;
			SceneManager.LoadScene("wrong");
		} 

		if(col.gameObject.tag == "correct"){
			Destroy (col.gameObject);
			correctnum--;

			PlayerPrefs.SetFloat("timeKey", time);
			PlayerPrefs.SetInt("itemKey", itemnum);
			PlayerPrefs.SetInt("correctKey", correctnum);
			PlayerPrefs.SetInt("wrongKey", wrongnum);
			PlayerPrefs.Save();

			managerPara.playerPos = this.gameObject.transform.position;
			managerPara.soundTime = soundPara.audioSource.time;
			SceneManager.LoadScene("correct");
		} 
	}
		
	void Move(){
		Vector3 movement = transform.forward * movementInputValue * moveSpeed * Time.deltaTime;
		transform.position += movement;
	}

	void Turn(){
		float turn = turnInputValue * turnSpeed * Time.deltaTime;

		Quaternion turnRotation = Quaternion.Euler(0f, turn, 0f);
		transform.rotation *= turnRotation;
	}
}
