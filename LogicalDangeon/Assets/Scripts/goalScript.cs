using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class goalScript : MonoBehaviour {

	public Text timeResult;
	public float time;
	public Text scoreResult;

	managerScript managerPara;
	public GameObject manager;

	void Awake () {
		manager = GameObject.Find ("Manager");
		managerPara = manager.GetComponent<managerScript> ();
	}

	void Start(){
		time = managerPara.time;
		timeResult.text = "Time : "+time.ToString();
		Debug.Log (time);
		Debug.Log (timeResult.name);
		if(time >= 240.0f){
			scoreResult.text = "Very Logical!";
		}else if(120.0f <= time && time< 240.0f){
			scoreResult.text = "Logical Ordinally";
		}else if(60.0f <= time && time < 120.0f){
			scoreResult.text = "Train Logical Power";
		}else if(time < 60.0f){
			scoreResult.text = "Mazing...";
		}
	}
}
