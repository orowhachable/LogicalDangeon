using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemScript : MonoBehaviour {
	public int itemnum;
	managerScript managerPara;
	public GameObject manager;

	// Use this for initialization
	void Awake () {
		manager = GameObject.Find("Manager");
		managerPara = manager.GetComponent<managerScript>();
	}

	void OnCollisionEnter(Collision col){
		if(col.gameObject.tag == "Player"){
			managerPara.itemName = itemnum;
			managerPara.itemState [itemnum] = false;
			Destroy (this.gameObject);
		}
	}
}
