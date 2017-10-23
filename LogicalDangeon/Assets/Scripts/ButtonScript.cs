using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ButtonScript : MonoBehaviour {
	managerScript managerPara;
	public GameObject manager;

	soundScript soundPara;
	public GameObject soundObject;

	void Start(){
		manager = GameObject.Find ("Manager");
		managerPara = manager.GetComponent<managerScript> ();

		soundObject = GameObject.Find ("SoundObject");
		soundPara = soundObject.GetComponent<soundScript> ();
	}
		

	public void ButtonPush() {
		Destroy (manager);
		SceneManager.LoadScene ("main");
	}

	public void ReturnPush(){
		if(Application.loadedLevelName == "quiz"){
			managerPara.soundTime = soundPara.audioSource.time;
		}
		SceneManager.LoadScene ("main");
	}

	public void ReturnPush2(){
		SceneManager.LoadScene ("main");
	}
}