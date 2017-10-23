using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soundScript : MonoBehaviour {
	public AudioSource audioSource;
	public AudioClip audioClip;

	managerScript managerPara;
	public GameObject manager;

	void Awake(){
		manager = GameObject.Find ("Manager");
		managerPara = manager.GetComponent<managerScript> ();
	}
		
	void Start () {
		audioSource = gameObject.GetComponent<AudioSource> ();
		audioSource.clip = audioClip;
		audioSource.time = managerPara.soundTime;
		if(Application.loadedLevelName == "Goal"){
			audioSource.time  = 0.0f;
		}
		audioSource.Play ();
	}

	void Update () {
		if(Application.loadedLevelName == "main"){
			audioSource.volume = 1.0f;
		}else if(Application.loadedLevelName == "Game Over"){
			
		}else if(Application.loadedLevelName == "Goal"){
			if(audioSource.time <= 10.0f){
				audioSource.volume = 1.0f;
			}else if(audioSource.time > 10.0f && audioSource.time <= 26.0f){
				audioSource.volume -= 0.05f*Time.deltaTime;
			}else if(audioSource.time <= 60.0f){
				audioSource.volume = 0.2f;
			}
		}else if(Application.loadedLevelName == "wrong" || Application.loadedLevelName == "correct"){
			audioSource.Stop();
		}else if(Application.loadedLevelName == "quiz"){
			audioSource.volume = 0.2f;
		}
	}
}
