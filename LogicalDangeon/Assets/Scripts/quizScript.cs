using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class quizScript : MonoBehaviour {
	public Image[] quizImage;
	Sprite imageName;

	public string quizName;
	public string quizNum;

	managerScript managerPara;
	public GameObject manager;

	void Awake () {
		manager = GameObject.Find("Manager");
		managerPara = manager.GetComponent<managerScript>();
	}

	// Use this for initialization
	void Start () {
		for(int i = 0; i < 12;i++){
			Sprite imageName = Resources.Load("quiz"+i.ToString(), typeof(Sprite)) as Sprite;
			quizName = imageName.name;
			quizNum = quizName.Remove (0, 4);
			quizImage[i] = GetComponent<Image> ();
			if(quizNum == managerPara.itemName.ToString()){
				quizImage[i].sprite = imageName;
			}

		}
		
	}
}
